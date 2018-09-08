using System.Collections.Generic;
using TestWrapper.Config.Worker.Interfaces;

namespace TestWrapper.Config.Worker
{
    public class WorkConfigDefault : WorkConfig, IWorkConfigDefault
    {
        protected override void AppendToString(Dictionary<string, string> fields)
        {
        }
    }
}