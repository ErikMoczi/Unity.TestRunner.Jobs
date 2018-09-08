namespace WorkSpace.Tests.Base
{
    public interface ITestSettings
    {
        TestCaseWrapper TestCaseWrapper { get; }
        int DataSize { get; }
        int TotalRuns { get; }
    }
}