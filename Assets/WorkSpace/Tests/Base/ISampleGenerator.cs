using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;

namespace WorkSpace.Tests.Base
{
    public interface ISampleGenerator
    {
        ISampleConfig[] InitSampleConfigs();
        IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize);
    }
}