namespace Notification.Pattern.Api.Core
{
    public class Notification : Notification<object>
    {
        public Notification()
        {
        }

        public Notification(object outputData)
            : base(outputData)
        {
        }

        public virtual TData GetOutputData<TData>()
        {
            return (TData)base.GetOutputData();
        }
    }
}
