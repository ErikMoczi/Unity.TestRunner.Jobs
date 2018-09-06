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
    public sealed class Double4TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double4TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double4), DataConfig.DataDouble4),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<double4>, NativeArray<double4>, NativeArray<double4>>
                    .Run<SimdSubtractionDouble4Job>(
                        TestName(),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<double4>, NativeArray<double4>, NativeArray<double4>>
                    .Run<SimdSubtractionDouble4JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<double4[], double4[], double4[]>.Run<SimdSubtractionDouble4Plain>(
                    TestName(),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<double4[], double4[], double4[]>.Run<SimdSubtractionDouble4SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
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