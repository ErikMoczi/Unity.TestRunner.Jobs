using TestCase.Basic.Division.Simple.Optimization;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Division.Simple.Optimization
{
    public sealed class Double1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double), DataConfig.DataDouble1),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<double>, NativeArray<double>, NativeArray<double>>
                    .Run<SimpleDivisionOptimizationDoubleJob>(
                        TestName(),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<double>, NativeArray<double>, NativeArray<double>>
                    .Run<SimpleDivisionOptimizationDoubleJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
            };
        }
    }
}