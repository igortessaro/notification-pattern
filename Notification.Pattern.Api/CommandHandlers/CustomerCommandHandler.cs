using Notification.Pattern.Api.Commands.Customer;
using System.Threading;
using System.Threading.Tasks;

namespace Notification.Pattern.Api.CommandHandlers
{
    public class CustomerCommandHandler : IAsyncCommandHandler<CreateCustomerCommand>
    {
        public async Task<Core.Notification> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Core.Notification result = new Core.Notification();

            return result;
        }
    }
}
