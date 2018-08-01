using System.Collections.Generic;
using Unity.Collections;

namespace TestRunner.Wrappers.Base.Config
{
    public class WorkConfigIJob : WorkConfig, IWorkConfigIJob
    {
        public Allocator Allocator { get; }
        public bool Scheduled { get; }

        public WorkConfigIJob(Allocator allocator, bool scheduled = false)
        {
            Allocator = allocator;
            Scheduled = scheduled;
        }

        protected override void AppendToString(Dictionary<string, string> fields)
        {
            fields.Add(nameof(Allocator), Allocator.ToString());
            fields.Add(nameof(Scheduled), Scheduled.ToString());
        }
    }
}