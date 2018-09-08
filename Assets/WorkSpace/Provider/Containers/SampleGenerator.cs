using TestWrapper.Facades;
using TestWrapper.Generator.Interfaces;

namespace WorkSpace.Provider.Containers
{
    internal abstract class SampleGenerator : ISampleGenerator
    {
        public abstract string TestName();
        public abstract ISampleConfig[] InitSampleConfigs();
        public abstract IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize);
    }
}