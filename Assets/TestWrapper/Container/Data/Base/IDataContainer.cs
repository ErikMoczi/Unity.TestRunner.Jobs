using TestWrapper.Container.Info.Methods;

namespace TestWrapper.Container.Data.Base
{
    internal interface IDataContainer<T> : IRefreshContainer, IInfoData
    {
        T Value { get; }
    }
}