using TestRunner.Wrappers.Base.Config;
using Unity.Jobs;

namespace TestRunner.Workers.Extensions
{
    internal static class IJobExtendedExtensions
    {
        public static void RunTest<T>(this T job, IWorkConfigIJob config)
            where T : struct, IJobExt
        {
            if (config.Scheduled)
            {
                job.Schedule().Complete();
            }
            else
            {
                job.Run();
            }
        }
    }
}