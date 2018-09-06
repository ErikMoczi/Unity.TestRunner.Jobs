namespace TestRunner.Container.SetUp
{
    internal interface IContainerSetUp
    {
        string Name { get; }
        string Config { get; }
        string Namespace { get; }
    }
}