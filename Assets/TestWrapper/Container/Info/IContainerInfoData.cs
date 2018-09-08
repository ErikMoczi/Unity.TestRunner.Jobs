namespace TestWrapper.Container.Info
{
    public interface IContainerInfoData : IContainerInfo
    {
        string Name { get; }
        string Namespace { get; }
    }
}