using System.Collections.Generic;
using TestRunner.Config.Worker.Interfaces;

namespace TestRunner.Config.Worker
{
    public class WorkConfigUnityJob : WorkConfig, IWorkConfigUnityJob
    {
        public bool Scheduled { get; }

        public WorkConfigUnityJob(bool scheduled = true)
        {
            Scheduled = scheduled;
        }

        protected override void AppendToString(Dictionary<string, string> fields)
        {
            fields.Add(nameof(Scheduled), Scheduled.ToString());
        }
    }
}