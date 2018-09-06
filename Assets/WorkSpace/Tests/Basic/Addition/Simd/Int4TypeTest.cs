using TestCase.Basic.Addition.Simd;
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

namespace WorkSpace.Tests.Basic.Addition.Simd
{
    public sealed class Int4TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int4TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int4), DataConfig.DataInt4),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<int4>, NativeArray<int4>, NativeArray<int4>>.Run<SimdAdditionInt4Job>(
                    TestName(),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<int4>, NativeArray<int4>, NativeArray<int4>>
                    .Run<SimdAdditionInt4JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                        inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                        inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<int4[], int4[], int4[]>.Run<SimdAdditionInt4Plain>(
                    TestName(),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<int4[], int4[], int4[]>.Run<SimdAdditionInt4SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
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