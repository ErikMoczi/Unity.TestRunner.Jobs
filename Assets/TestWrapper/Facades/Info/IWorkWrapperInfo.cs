using TestWrapper.Container.Info;

namespace TestWrapper.Facades.Info
{
    public interface IWorkWrapperInfo
    {
        string TestName { get; }
        IContainerInfoWorker InfoWorker { get; }
        IContainerInfoDataArray InfoDataArray { get; }
    }
}