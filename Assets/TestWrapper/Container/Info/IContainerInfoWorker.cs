namespace TestWrapper.Container.Info
{
    public interface IContainerInfoWorker : IContainerInfoData
    {
        string JobType { get; }
    }
}