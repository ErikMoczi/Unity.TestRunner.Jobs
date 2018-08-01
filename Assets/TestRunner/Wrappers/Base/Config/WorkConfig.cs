using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TestRunner.Wrappers.Base.Config
{
    public abstract class WorkConfig : IWorkConfig
    {
        public sealed override string ToString()
        {
            StringBuilder mergeFields = new StringBuilder();
            var fields = GetFieldsToDisplay();
            foreach (var field in fields)
            {
                mergeFields.Append($"{field.Key}: {field.Value}");
                if (!field.Key.Equals(fields.Last().Key))
                {
                    mergeFields.Append(", ");
                }
            }

            return $"{{{mergeFields}}}";
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