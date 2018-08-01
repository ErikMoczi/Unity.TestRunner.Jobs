using TestRunner.Wrappers.Base.Config;

namespace TestRunner.Workers.Extensions
{
    internal static class INonJobExtensions
    {
        public static void RunTest<T>(this T job, IWorkConfigINonJob config)
            where T : struct, INonJobExt
        {
            job.Execute();
        }
    }
}