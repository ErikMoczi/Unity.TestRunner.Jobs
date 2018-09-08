using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestWrapper.Config
{
    public abstract class BaseConfig : IBaseConfig
    {
        public sealed override string ToString()
        {
            var mergeFields = new StringBuilder();
            var fields = GetFieldsToDisplay();
            foreach (var field in fields)
            {
                mergeFields.Append($"{field.Key}: {field.Value}");
                if (!field.Key.Equals(fields.Last().Key))
                {
                    mergeFields.Append(", ");
                }
            }

            return string.IsNullOrEmpty(mergeFields.ToString()) ? string.Empty : $"[{mergeFields}]";
        }


        private Dictionary<string, string> GetFieldsToDisplay()
        {
            var fields = new Dictionary<string, string>();
            AppendToString(fields);
            return fields;
        }

        protected abstract void AppendToString(Dictionary<string, string> fields);
    }
}