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
    public sealed class Double2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double2), DataConfig.DataDouble2),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<double2>, NativeArray<double2>, NativeArray<double2>>
                    .Run<SimdSubtractionDouble2Job>(
                        TestName(),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<double2>, NativeArray<double2>, NativeArray<double2>>
                    .Run<SimdSubtractionDouble2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<double2[], double2[], double2[]>.Run<SimdSubtractionDouble2Plain>(
                    TestName(),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<double2[], double2[], double2[]>.Run<SimdSubtractionDouble2SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
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