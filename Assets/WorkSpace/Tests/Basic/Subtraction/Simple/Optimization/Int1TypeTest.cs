using TestCase.Basic.Subtraction.Simple.Optimization;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simple.Optimization
{
    public sealed class Int1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), DataConfig.DataInt1),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<int>, NativeArray<int>, NativeArray<int>>
                    .Run<SimpleSubtractionOptimizationIntJob>(
                        TestName(),
                        inputDataContainer.GetData<int>(DataConfig.DataInt1),
                        inputDataContainer.GetData<int>(DataConfig.DataInt1),
                        inputDataContainer.GetData<int>(DataConfig.DataInt1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<int>, NativeArray<int>, NativeArray<int>>
                    .Run<SimpleSubtractionOptimizationIntJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int>(DataConfig.DataInt1),
                        inputDataContainer.GetData<int>(DataConfig.DataInt1),
                        inputDataContainer.GetData<int>(DataConfig.DataInt1),
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