using System;
using System.Collections.Generic;
using System.Linq;

namespace Notification.Pattern.Api.Core
{
    public class Notification<TData> : INotification
    {
        private readonly Dictionary<string, NotificationEntry> errors = new Dictionary<string, NotificationEntry>();
        private readonly Dictionary<string, NotificationEntry> warnings = new Dictionary<string, NotificationEntry>();
        private readonly Dictionary<string, NotificationEntry> validations = new Dictionary<string, NotificationEntry>();

        public Notification()
        {
        }

        public Notification(TData outputData)
        {
            if (outputData == null)
            {
                throw new ArgumentNullException(nameof(outputData));
            }

            this.OutputData = outputData;
        }

        public bool HasMessages => this.errors.Any() || this.warnings.Any() || this.validations.Any();

        public IReadOnlyDictionary<string, NotificationEntry> Errors => this.errors;

        public IReadOnlyDictionary<string, NotificationEntry> Warnings => this.warnings;

        public IReadOnlyDictionary<string, NotificationEntry> Validations => this.validations;

        public bool HasOutputData => this.OutputData != null;

        public TData OutputData { get; private set; }

        public void AddError(string key, string message)
        {
            AddMessage(key, message, this.errors);
        }

        public void AddWarning(string key, string message)
        {
            AddMessage(key, message, this.warnings);
        }

        public void AddValidation(string key, string message)
        {
            AddMessage(key, message, this.validations);
        }

        public virtual TData GetOutputData()
        {
            if (this.OutputData == null)
            {
                return default;
            }

            return this.OutputData;
        }

        private static void AddMessage(string key, string message, Dictionary<string, NotificationEntry> entries)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (string.IsNullOrEmpty(message))
            {
                throw new ArgumentNullException(nameof(message));
            }

            if (!entries.TryGetValue(key, out NotificationEntry entry))
            {
                entry = new NotificationEntry();
                entries.Add(key, entry);
            }

            entry.AddMessage(message);
        }
    }
}
