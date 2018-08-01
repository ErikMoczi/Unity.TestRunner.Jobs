using TestRunner.Wrappers.Base.Config;
using Unity.Jobs;

namespace TestRunner.Workers.Extensions
{
    internal static class IJobParallelForExtendedExtensions
    {
        public static void RunTest<T>(this T job, IWorkConfigIJobParallelFor config, int dataSize)
            where T : struct, IJobParallelForExt
        {
            if (config.Scheduled)
            {
                job.Schedule(dataSize, config.BatchCount).Complete();
            }
            else
            {
                job.Run(dataSize);
            }
        }
    }
}