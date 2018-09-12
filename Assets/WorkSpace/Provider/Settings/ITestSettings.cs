using Unity.PerformanceTesting;
using WorkSpace.Provider.Containers;

namespace WorkSpace.Provider.Settings
{
    public interface ITestSettings
    {
        TestCaseWrapper TestCaseWrapper { get; }
        int DataSize { get; }
        int TotalRuns { get; }
        int WarmUpCount { get; }
        int ResultsPrecision { get; }
        SampleUnit SampleUnit { get; }
    }
}