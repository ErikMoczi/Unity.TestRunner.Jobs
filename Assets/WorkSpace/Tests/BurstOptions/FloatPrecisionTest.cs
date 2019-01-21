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
    internal sealed class FloatPrecisionTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(FloatPrecisionTest);
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

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatPrecisionStdJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatPrecisionLowJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatPrecisionMedJob>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatPrecisionHighJob>(
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

                #endregion

                #region IJobParallelFor

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatPrecisionStdJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatPrecisionLowJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatPrecisionMedJobParallelFor>(
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
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstFloatPrecisionHighJobParallelFor>(
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

                #endregion
            };
        }
    }
}