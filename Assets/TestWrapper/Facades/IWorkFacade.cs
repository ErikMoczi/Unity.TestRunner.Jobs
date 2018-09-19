using TestWrapper.Facades.Info;
using TestWrapper.Utils.Interfaces;

namespace TestWrapper.Facades
{
    public interface IWorkFacade : ISetUp, ICleanUp, IRun
    {
        IWorkWrapperInfo Info();
    }
}