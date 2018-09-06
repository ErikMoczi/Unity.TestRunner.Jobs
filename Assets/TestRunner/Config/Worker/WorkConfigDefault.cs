using System.Collections.Generic;
using TestRunner.Config.Worker.Interfaces;

namespace TestRunner.Config.Worker
{
    public class WorkConfigDefault : WorkConfig, IWorkConfigDefault
    {
        protected override void AppendToString(Dictionary<string, string> fields)
        {
        }
    }
}