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
    public sealed class Float4TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Float4TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float4), DataConfig.DataFloat4),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<float4>, NativeArray<float4>, NativeArray<float4>>
                    .Create<SimdMultiplicationFloat4Job>(
                        TestName(),
                        inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                        inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                        inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<float4>, NativeArray<float4>, NativeArray<float4>>
                    .Create<SimdMultiplicationFloat4JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                        inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                        inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<float4[], float4[], float4[]>.Create<SimdMultiplicationFloat4Plain>(
                    TestName(),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<float4[], float4[], float4[]>.Create<SimdMultiplicationFloat4SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
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