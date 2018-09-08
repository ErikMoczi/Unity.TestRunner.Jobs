using TestWrapper.Facades;
using TestWrapper.Generator.Interfaces;

namespace WorkSpace.Provider.Containers
{
    internal interface ISampleGenerator
    {
        string TestName();
        ISampleConfig[] InitSampleConfigs();
        IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize);
    }
}