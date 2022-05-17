using Ecommerence.Domain.Events.Common;

namespace Ecommerence.Domain.Events.Interfaces
{
    public interface IHandler<in T> where T : Message
    {
        void Handle(T message);
    }
}
