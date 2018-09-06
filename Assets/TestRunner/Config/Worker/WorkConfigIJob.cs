using TestRunner.Config.Worker.Interfaces;

namespace TestRunner.Config.Worker
{
    public class WorkConfigIJob : WorkConfigUnityJob, IWorkConfigIJob
    {
        public WorkConfigIJob(bool scheduled = true) : base(scheduled)
        {
        }
    }
}