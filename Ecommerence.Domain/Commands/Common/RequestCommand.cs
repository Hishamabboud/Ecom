using MediatR;

namespace Ecommerence.Domain.Commands.Common
{
    public abstract class RequestCommand<TResult> : Command, IRequest<TResult>
    {
    }
}
