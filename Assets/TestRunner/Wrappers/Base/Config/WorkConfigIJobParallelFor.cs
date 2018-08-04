using System.Collections.Generic;
using Unity.Collections;

namespace TestRunner.Wrappers.Base.Config
{
    public class WorkConfigIJobParallelFor : WorkConfigIJob, IWorkConfigIJobParallelFor
    {
        public int BatchCount { get; }

        public WorkConfigIJobParallelFor(Allocator allocator, bool scheduled = false, int batchCount = 64) : base(allocator,
            scheduled)
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