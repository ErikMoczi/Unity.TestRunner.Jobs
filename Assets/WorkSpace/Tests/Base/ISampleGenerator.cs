using TestRunner.Facades;
using TestRunner.Generator.Interfaces;

namespace WorkSpace.Tests.Base
{
    public interface ISampleGenerator
    {
        string TestName();
        ISampleConfig[] InitSampleConfigs();
        ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize);
    }
}