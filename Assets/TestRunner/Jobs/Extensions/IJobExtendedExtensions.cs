using Unity.Jobs;

namespace TestRunner.Jobs.Extensions
{
    internal static class IJobExtendedExtensions
    {
        public static void RunTest<T>(this T job, bool scheduled)
            where T : struct, IJobExtended
        {
            if (scheduled)
            {
                var jobHandle = job.Schedule();
                jobHandle.Complete();
            }
            else
            {
                job.Run();
            }
        }
    }
}