using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Ecommerence.Settings;
using Ecommerence.Repository.Contexts;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ecommerence.Setup
{
    public static class SetupHelper
    {
        private static string ApiTitle = "Ecommerence API";
        private static string ApiDocumentationName = "Ecommerence";

        public static IServiceCollection AddScopedByBaseType(this IServiceCollection services, Type baseType)
        {
            Assembly
                .GetAssembly(baseType)
                .GetTypesOf(baseType)
                .ForEach(type => services.AddScoped(type.GetInterface($"I{type.Name}"), type));

            return services;
        }

        public static IServiceCollection AddScopedHandlers(this IServiceCollection services, Type handlerType, Assembly assembly)
        {
            assembly
                .GetTypes()
                .ToList()
                .ForEach(type => 
                    type
                        .GetInterfaces()
                        .Where(@interface => @interface.IsGenericType && @interface.GetGenericTypeDefinition() == handlerType)
                        .ToList()
                        .ForEach(@interface => services.AddScoped(@interface, type))
                );

            return services;
        }


        public static IServiceCollection AddSqlServerContexts(this IServiceCollection services, AppSettings settings)
        {
            services.AddDbContext<MainDbContext>(options =>
                options
                 
                    .UseMySQL("server = localhost; user = root; database = Ecom; password = Shutdown123; port = 3306")
            );

            services.AddDbContext<EventStoreSQLContext>(options =>
                options
                    
                    .UseMySQL("server = localhost; user = root; database = Ecom; password = Shutdown123; port = 3306")
            );

            return services;
        }

        public static IServiceCollection AddCustomMvc(this IServiceCollection services)
        {
            return services;
        }



        public static IApplicationBuilder UseSawaggerWithDocs(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", ApiDocumentationName);
            });
             
            return app;
        }

        public static IApplicationBuilder UseDatabaseInitialization(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<MainDbContext>().Database.Migrate();
                scope.ServiceProvider.GetRequiredService<EventStoreSQLContext>().Database.Migrate();
            }

            return app;
        }

        public static IApplicationBuilder UseCustomCors(this IApplicationBuilder app)
        {
            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                builder.AllowAnyOrigin();
            });

            return app;
        }

        public static IApplicationBuilder UseDeveloperExceptionPageIfDebug(this IApplicationBuilder app, Microsoft.AspNetCore.Hosting.IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            return app;
        }



        public static List<Type> GetTypesOf(this Assembly assembly, Type baseType) => assembly
                .GetTypes()
                .Where(type =>
                    type.BaseType != null
                    && (
                        (type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == baseType)) // -> Generics, ex: CrudRepository<>
                        || (baseType.IsAssignableFrom(type) && !type.IsAbstract) // -> Non generics, ex: Repository
                    )
                .ToList();
    }
}
