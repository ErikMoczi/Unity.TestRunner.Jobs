using TestWrapper.Facades;
using TestWrapper.Generator.Interfaces;

namespace WorkSpace.Tests.Base
{
    public interface ISampleGenerator
    {
        string TestName();
        ISampleConfig[] InitSampleConfigs();
        IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize);
    }
}