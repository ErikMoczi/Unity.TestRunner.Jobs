using TestWrapper.Utils.Interfaces;

namespace TestWrapper.Container
{
    internal interface IRefreshContainer : IBaseContainer, ISetUp, ICleanUp
    {
    }
}