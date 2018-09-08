using TestWrapper.Config.Worker.Interfaces;

namespace TestWrapper.Config.Worker
{
    public class WorkConfigIJob : WorkConfigUnityJob, IWorkConfigIJob
    {
        public WorkConfigIJob(bool scheduled = true) : base(scheduled)
        {
        }
    }
}