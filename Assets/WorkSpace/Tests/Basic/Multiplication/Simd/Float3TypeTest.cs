using TestCase.Basic.Multiplication.Simd;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;
using DataConfig = WorkSpace.Tests.Base.DataConfig;

namespace WorkSpace.Tests.Basic.Multiplication.Simd
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

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<float3>, NativeArray<float3>, NativeArray<float3>>
                    .Create<SimdMultiplicationFloat3Job>(
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
                WorkerFactory<NativeArray<float3>, NativeArray<float3>, NativeArray<float3>>
                    .Create<SimdMultiplicationFloat3JobParallelFor>(
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
                WorkerFactory<float3[], float3[], float3[]>.Create<SimdMultiplicationFloat3Plain>(
                    TestName(),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<float3[], float3[], float3[]>.Create<SimdMultiplicationFloat3SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
            };
        }
    }
}