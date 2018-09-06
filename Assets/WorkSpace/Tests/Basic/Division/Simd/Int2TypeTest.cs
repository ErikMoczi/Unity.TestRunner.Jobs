using TestCase.Basic.Division.Simd;
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

namespace WorkSpace.Tests.Basic.Division.Simd
{
    public sealed class Int2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int2), DataConfig.DataInt2),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<int2>, NativeArray<int2>, NativeArray<int2>>.Run<SimdDivisionInt2Job>(
                    TestName(),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<int2>, NativeArray<int2>, NativeArray<int2>>
                    .Run<SimdDivisionInt2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                        inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                        inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<int2[], int2[], int2[]>.Run<SimdDivisionInt2Plain>(
                    TestName(),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<int2[], int2[], int2[]>.Run<SimdDivisionInt2SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
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