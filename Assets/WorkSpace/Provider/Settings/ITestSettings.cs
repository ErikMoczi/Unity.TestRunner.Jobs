using WorkSpace.Provider.Containers;

namespace WorkSpace.Provider.Settings
{
    public interface ITestSettings
    {
        TestCaseWrapper TestCaseWrapper { get; }
        int DataSize { get; }
        int TotalRuns { get; }
    }
}