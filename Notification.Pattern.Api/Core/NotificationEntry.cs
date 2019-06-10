using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Notification.Pattern.Api.Core
{
    public sealed class NotificationEntry
    {
        private readonly List<string> messages = new List<string>();

        internal NotificationEntry()
        {
        }

        [JsonConstructor]
        internal NotificationEntry(IList<string> messages)
        {
            if (messages == null)
                throw new ArgumentNullException(nameof(messages));

            this.messages.AddRange(messages);
        }

        public IReadOnlyList<string> Messages => this.messages;

        internal void AddMessage(string message)
        {
            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (this.messages.Exists(match => match.Equals(message, StringComparison.InvariantCultureIgnoreCase)))
            {
                return;
            }

            this.messages.Add(message);
        }
    }
}
