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
    public sealed class UInt2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint2), DataConfig.DataUInt2),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<uint2>, NativeArray<uint2>, NativeArray<uint2>>.Run<SimdSubtractionUInt2Job>(
                    TestName(),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<uint2>, NativeArray<uint2>, NativeArray<uint2>>
                    .Run<SimdSubtractionUInt2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<uint2[], uint2[], uint2[]>.Run<SimdSubtractionUInt2Plain>(
                    TestName(),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<uint2[], uint2[], uint2[]>.Run<SimdSubtractionUInt2SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
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