using TestCase.Basic.Multiplication.Simd;
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

namespace WorkSpace.Tests.Basic.Multiplication.Simd
{
    public sealed class UInt4TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt4TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint4), DataConfig.DataUInt4),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<uint4>, NativeArray<uint4>, NativeArray<uint4>>.Run<SimdMultiplicationUInt4Job>(
                    TestName(),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<uint4>, NativeArray<uint4>, NativeArray<uint4>>
                    .Run<SimdMultiplicationUInt4JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                        inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                        inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<uint4[], uint4[], uint4[]>.Run<SimdMultiplicationUInt4Plain>(
                    TestName(),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<uint4[], uint4[], uint4[]>.Run<SimdMultiplicationUInt4SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
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