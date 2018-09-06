using TestCase.Basic.Subtraction.Simd.Optimization;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simd.Optimization
{
    public sealed class Float2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Float2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float2), DataConfig.DataFloat2),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<float2>, NativeArray<float2>, NativeArray<float2>>
                    .Run<SimdSubtractionOptimizationFloat2Job>(
                        TestName(),
                        inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                        inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                        inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<float2>, NativeArray<float2>, NativeArray<float2>>
                    .Run<SimdSubtractionOptimizationFloat2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                        inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                        inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
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