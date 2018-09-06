using TestRunner.Facades;
using TestRunner.Generator.Interfaces;

namespace WorkSpace.Tests.Base
{
    public abstract class SampleGenerator : ISampleGenerator
    {
        public abstract string TestName();
        public abstract ISampleConfig[] InitSampleConfigs();
        public abstract ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize);
    }
}