using MediatR;

namespace Notification.Pattern.Api.Commands
{
    public interface ICommand : IRequest<Core.Notification>
    {
    }
}
