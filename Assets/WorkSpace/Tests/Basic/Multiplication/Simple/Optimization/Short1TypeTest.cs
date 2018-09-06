using TestCase.Basic.Multiplication.Simple.Optimization;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Multiplication.Simple.Optimization
{
    public sealed class Short1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Short1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(short), DataConfig.DataShort1),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<short>, NativeArray<short>, NativeArray<short>>
                    .Run<SimpleMultiplicationOptimizationShortJob>(
                        TestName(),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<short>, NativeArray<short>, NativeArray<short>>
                    .Run<SimpleMultiplicationOptimizationShortJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
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