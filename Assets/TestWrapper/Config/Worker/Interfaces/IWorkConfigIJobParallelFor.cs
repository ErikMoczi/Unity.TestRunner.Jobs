namespace TestWrapper.Config.Worker.Interfaces
{
    public interface IWorkConfigIJobParallelFor : IWorkConfigUnityJob
    {
        int BatchCount { get; }
    }
}