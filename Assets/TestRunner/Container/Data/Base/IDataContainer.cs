using TestRunner.Container.SetUp;

namespace TestRunner.Container.Data.Base
{
    internal interface IDataContainer<T> : IRefreshContainer, IContainerInfo
    {
        T Value { get; }
    }
}