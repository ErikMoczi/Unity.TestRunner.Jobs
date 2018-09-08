namespace TestWrapper.Container.Info
{
    public interface IContainerInfoDataArray
    {
        IContainerInfoData this[int index] { get; }
        int Length { get; }
    }
}