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

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<float2>, NativeArray<float2>, NativeArray<float2>>
                    .Create<SimdMultiplicationFloat2Job>(
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
                WorkerFactory<NativeArray<float2>, NativeArray<float2>, NativeArray<float2>>
                    .Create<SimdMultiplicationFloat2JobParallelFor>(
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
                WorkerFactory<float2[], float2[], float2[]>.Create<SimdMultiplicationFloat2Plain>(
                    TestName(),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<float2[], float2[], float2[]>.Create<SimdMultiplicationFloat2SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
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