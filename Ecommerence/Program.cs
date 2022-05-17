
using Ecommerence.Auth;
using Ecommerence.Settings;
using Ecommerence.Setup;
using Ecommerence.Bus;
using Ecommerence.Domain.Bus;
using Ecommerence.Domain.Handlers.Commands;
using Ecommerence.Domain.Handlers.Events;
using Ecommerence.Domain.Interfaces.Identity;
using Ecommerence.Domain.Interfaces.Repositories.Common;
using Ecommerence.Repository.Repositories.Common;
using Ecommerence.Repository.UoW;
using MediatR;
using Ecommerence.API.Auth;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;


var builder = WebApplication.CreateBuilder(args);


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
AppSettings appSettings = new AppSettings();

IServiceCollection ServiceCollection = builder.Services
                .AddDistributedMemoryCache()
                .AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies())
                .AddCustomMvc()
                .Configure<IdentityOptions>(options =>
                 options.ClaimsIdentity.UserIdClaimType = ClaimTypes.NameIdentifier)
                .AddSingleton(appSettings)
                .AddSqlServerContexts(appSettings)
                .AddHttpContextAccessor()
                .AddMediatR(typeof(IMediatorHandler))
                .AddJwtAuth(appSettings)
                .AddScoped<IUnitOfWork, UnitOfWork>()
                .AddScoped<IMediatorHandler, InMemoryBus>()
                .AddScoped<IUser, UserControl>()
                .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
                .AddScopedByBaseType(typeof(CrudRepository<>)) // -> Repositories
                .AddScopedHandlers(typeof(INotificationHandler<>), typeof(UserEventHandler).Assembly) // -> Events
                .AddScopedHandlers(typeof(IRequestHandler<>), typeof(UserCommandHandler).Assembly) // -> Commands
          
;





var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

}

app.UseCors(options =>
{
    options.AllowAnyHeader()
        .AllowAnyMethod()
        .AllowCredentials()
        .WithOrigins("http://localhost:3000");
});


app.UseAuthorization();

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
    c.RoutePrefix = string.Empty;
});


app.MapControllers();



app.Run();
