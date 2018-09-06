namespace TestRunner.Container.SetUp
{
    internal interface IContainerWorkerSetUp : IContainerSetUp
    {
        string JobType { get; }
    }
}