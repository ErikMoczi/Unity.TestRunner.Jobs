namespace TestRunner.Config.Worker.Interfaces
{
    public interface IWorkConfigIJobParallelFor : IWorkConfigUnityJob
    {
        int BatchCount { get; }
    }
}