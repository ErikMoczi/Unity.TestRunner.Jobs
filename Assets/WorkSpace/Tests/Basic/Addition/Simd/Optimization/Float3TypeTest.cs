using TestCase.Basic.Addition.Simd.Optimization;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Provider.Containers;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Tests.Basic.Addition.Simd.Optimization
{
    internal sealed class Float3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Float3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float3), TypeConfig.DataFloat3),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<float3>, NativeArray<float3>, NativeArray<float3>>
                    .Create<SimdAdditionOptimizationFloat3Job>(
                        TestName(),
                        inputDataContainer.GetData<float3>(TypeConfig.DataFloat3),
                        inputDataContainer.GetData<float3>(TypeConfig.DataFloat3),
                        inputDataContainer.GetData<float3>(TypeConfig.DataFloat3),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<float3>, NativeArray<float3>, NativeArray<float3>>
                    .Create<SimdAdditionOptimizationFloat3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float3>(TypeConfig.DataFloat3),
                        inputDataContainer.GetData<float3>(TypeConfig.DataFloat3),
                        inputDataContainer.GetData<float3>(TypeConfig.DataFloat3),
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