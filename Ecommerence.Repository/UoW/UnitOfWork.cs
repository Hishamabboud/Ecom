using Microsoft.EntityFrameworkCore;
using Ecommerence.Domain.Interfaces.Repositories.Common;
using Ecommerence.Repository.Contexts;
using System;
using System.Linq;

namespace Ecommerence.Repository.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext context;

        public UnitOfWork(MainDbContext context) => this.context = context;

        public void Commit()
        {
            if (context.ChangeTracker.Entries().Any(e => new[] { EntityState.Added, EntityState.Deleted, EntityState.Modified }.Contains(e.State)))
                context.SaveChanges();
        }

        public void Dispose() => context.Dispose();
    }
}
