using TestCase.BurstOptions;
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

namespace WorkSpace.Tests.BurstOptions
{
    internal sealed class FloatModeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(FloatModeTest);
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

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeDefaultJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeDefaultJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeFastJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeFastJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeStrictJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeStrictJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeDeterministicJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeDeterministicJob>(
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

                #region IJobParallelFor

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeDefaultJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeDefaultJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeFastJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeFastJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeStrictJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeStrictJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeDeterministicJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatModeDeterministicJobParallelFor>(
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
            };
        }
    }
}