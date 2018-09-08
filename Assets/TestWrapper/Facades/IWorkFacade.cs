using TestWrapper.Facades.Info;

namespace TestWrapper.Facades
{
    public interface IWorkFacade
    {
        void SetUp();
        void Run();
        void CleanUp();
        IWorkWrapperInfo Info();
    }
}