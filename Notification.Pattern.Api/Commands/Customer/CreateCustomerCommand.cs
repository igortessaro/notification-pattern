namespace Notification.Pattern.Api.Commands.Customer
{
    public class CreateCustomerCommand : ICommand
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
