using TestCase.Basic;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.ConfigVariation
{
    public sealed class AllocatorTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(AllocatorTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float), DataConfig.DataFloat1),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                #region IJob

                #region Persistent

                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),

                #endregion

                #region Temp

                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),

                #endregion

                #region TempJob

                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),

                #endregion

                #endregion

                #region IJobParallelFor

                #region Persistent

                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),

                #endregion

                #region Temp

                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),

                #endregion

                #region TempJob

                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerTests<NativeArray<float>, NativeArray<float>>.Run<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),

                #endregion

                #endregion
            };
        }
    }
}