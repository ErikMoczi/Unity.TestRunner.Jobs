using TestCase.BurstOptions;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;
using DataConfig = WorkSpace.Tests.Base.DataConfig;

namespace WorkSpace.Tests.BurstOptions
{
    public sealed class SupportTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(SupportTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float), DataConfig.DataFloat1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                #region IJob

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstSupportRelaxedJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstSupportRelaxedJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstSupportStrictJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstSupportStrictJob>(
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

                #region IJobParallelFor

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstSupportRelaxedJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstSupportRelaxedJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstSupportStrictJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstSupportStrictJobParallelFor>(
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
            };
        }
    }
}