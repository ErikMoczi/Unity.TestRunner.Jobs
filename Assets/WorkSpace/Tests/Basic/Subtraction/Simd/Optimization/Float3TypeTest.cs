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
    public sealed class Float3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Float3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float3), DataConfig.DataFloat3),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<float3>, NativeArray<float3>, NativeArray<float3>>
                    .Run<SimdSubtractionOptimizationFloat3Job>(
                        TestName(),
                        inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                        inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                        inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<float3>, NativeArray<float3>, NativeArray<float3>>
                    .Run<SimdSubtractionOptimizationFloat3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                        inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                        inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
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