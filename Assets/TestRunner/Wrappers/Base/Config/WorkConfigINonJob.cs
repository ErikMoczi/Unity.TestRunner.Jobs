using System.Collections.Generic;

namespace TestRunner.Wrappers.Base.Config
{
    public class WorkConfigINonJob : WorkConfig, IWorkConfigINonJob
    {
        protected override void AppendToString(Dictionary<string, string> fields)
        {
        }
    }
}