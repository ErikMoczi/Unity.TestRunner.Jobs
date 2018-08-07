using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;

namespace WorkSpace.Tests.Base
{
    public abstract class SampleGenerator : ISampleGenerator
    {
        public abstract ISampleConfig[] InitSampleConfigs();
        public abstract IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize);
    }
}