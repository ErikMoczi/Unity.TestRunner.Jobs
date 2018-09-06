using TestRunner.Facades;

namespace TestRunner.Extensions
{
    internal static class IWorkFacadeExtension
    {
        internal static ITestFacade TestFacade(this IWorkFacade workFacade, string testName)
        {
            return new TestFacade<IWorkFacade>(testName, workFacade);
        }
    }
}