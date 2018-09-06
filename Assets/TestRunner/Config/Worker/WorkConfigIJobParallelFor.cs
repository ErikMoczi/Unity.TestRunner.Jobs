using System.Collections.Generic;
using TestRunner.Config.Worker.Interfaces;

namespace TestRunner.Config.Worker
{
    public class WorkConfigIJobParallelFor : WorkConfigUnityJob, IWorkConfigIJobParallelFor
    {
        public int BatchCount { get; }

        public WorkConfigIJobParallelFor(bool scheduled = true, int batchCount = 64) : base(scheduled)
        {
            BatchCount = batchCount;
        }

        protected override void AppendToString(Dictionary<string, string> fields)
        {
            base.AppendToString(fields);
            fields.Add(nameof(BatchCount), BatchCount.ToString());
        }
    }
}