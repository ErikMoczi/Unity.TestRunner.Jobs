using TestRunner.Container.SetUp;

namespace TestRunner.Facades.SetUp
{
    internal interface IWorkerWrapperSetUp
    {
        IContainerWorkerSetUp Worker { get; }
        IContainerSetUp[] MultiContainer { get; }
    }
}