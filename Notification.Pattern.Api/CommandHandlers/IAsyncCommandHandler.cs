using MediatR;
using Notification.Pattern.Api.Commands;

namespace Notification.Pattern.Api.CommandHandlers
{
    public interface IAsyncCommandHandler<in TCommand> : IRequestHandler<TCommand, Core.Notification>
       where TCommand : ICommand
    {
    }
}
