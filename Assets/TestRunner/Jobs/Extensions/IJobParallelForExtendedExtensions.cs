using Unity.Jobs;

namespace TestRunner.Jobs.Extensions
{
    internal static class IJobParallelForExtendedExtensions
    {
        public static void RunTest<T>(this T job, bool scheduled, int dataSize)
            where T : struct, IJobParallelForExtended
        {
            if (scheduled)
            {
                var handle = job.Schedule(dataSize, 64);
                handle.Complete();
            }
            else
            {
                job.Run(dataSize);
            }
        }
    }
}