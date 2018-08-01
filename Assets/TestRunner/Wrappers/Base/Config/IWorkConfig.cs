using Unity.Collections;

namespace TestRunner.Wrappers.Base.Config
{
    public interface IWorkConfig
    {
    }

    public interface IWorkConfigIJob : IWorkConfig
    {
        Allocator Allocator { get; }
        bool Scheduled { get; }
    }

    public interface IWorkConfigIJobParallelFor : IWorkConfigIJob
    {
        int BatchCount { get; }
    }

    public interface IWorkConfigINonJob : IWorkConfig
    {
    }
}