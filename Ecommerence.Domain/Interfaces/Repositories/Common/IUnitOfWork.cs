using System;

namespace Ecommerence.Domain.Interfaces.Repositories.Common
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
    }
}
