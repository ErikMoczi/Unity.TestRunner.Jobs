namespace TestWrapper.Container.Info.Methods
{
    internal interface IInfoWorker : IInfo
    {
        new IContainerInfoWorker Info();
    }
}