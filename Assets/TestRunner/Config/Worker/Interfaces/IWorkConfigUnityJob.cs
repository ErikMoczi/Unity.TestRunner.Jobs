namespace TestRunner.Config.Worker.Interfaces
{
    public interface IWorkConfigUnityJob : IWorkConfig
    {
        bool Scheduled { get; }
    }
}