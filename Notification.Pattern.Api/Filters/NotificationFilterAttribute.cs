using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Linq;
using System.Threading.Tasks;

namespace Notification.Pattern.Api.Filters
{
    public class NotificationFilterAttribute : ActionFilterAttribute
    {
        public override Task OnResultExecutionAsync(ResultExecutingContext context, ResultExecutionDelegate next)
        {
            var objectResult = context.Result as ObjectResult;

            if (objectResult?.Value is Core.Notification notification &&
                (notification.Errors.Any() || notification.Validations.Any()))
            {
                context.Result = new BadRequestObjectResult(notification);
            }

            return base.OnResultExecutionAsync(context, next);
        }
    }
}
