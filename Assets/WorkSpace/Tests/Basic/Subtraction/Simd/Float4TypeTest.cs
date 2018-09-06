using TestCase.Basic.Subtraction.Simd;
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

namespace WorkSpace.Tests.Basic.Subtraction.Simd
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

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<float4>, NativeArray<float4>, NativeArray<float4>>
                    .Run<SimdSubtractionFloat4Job>(
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
                WorkerTests<NativeArray<float4>, NativeArray<float4>, NativeArray<float4>>
                    .Run<SimdSubtractionFloat4JobParallelFor>(
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
                WorkerTests<float4[], float4[], float4[]>.Run<SimdSubtractionFloat4Plain>(
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
                WorkerTests<float4[], float4[], float4[]>.Run<SimdSubtractionFloat4SystemParallelFor>(
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