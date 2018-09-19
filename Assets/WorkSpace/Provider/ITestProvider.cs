using TestWrapper.Facades;

namespace WorkSpace.Provider
{
    public interface ITestProvider
    {
        IWorkFacade[] WorkFacades { get; }
    }
}