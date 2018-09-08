using TestCase.Basic;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Provider.Containers;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Tests.ConfigVariation
{
    internal sealed class AllocatorTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(AllocatorTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float), TypeConfig.DataFloat1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                #region IJob

                #region Persistent

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),

                #endregion

                #region Temp

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),

                #endregion

                #region TempJob

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
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

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),

                #endregion

                #region Temp

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Temp),
                        new DataConfigUnityCollection(Allocator.Temp),
                    }
                ),

                #endregion

                #region TempJob

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.TempJob),
                        new DataConfigUnityCollection(Allocator.TempJob),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BaseBurstIJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
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