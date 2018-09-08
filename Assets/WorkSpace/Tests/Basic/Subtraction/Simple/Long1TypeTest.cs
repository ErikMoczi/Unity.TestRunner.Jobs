using TestCase.Basic.Subtraction.Simple;
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

namespace WorkSpace.Tests.Basic.Subtraction.Simple
{
    internal sealed class Long1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Long1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(long), TypeConfig.DataLong1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<long>, NativeArray<long>, NativeArray<long>>.Create<SimpleSubtractionLongJob>(
                    TestName(),
                    inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                    inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                    inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<long>, NativeArray<long>, NativeArray<long>>
                    .Create<SimpleSubtractionLongJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                        inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                        inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<long[], long[], long[]>.Create<SimpleSubtractionLongPlain>(
                    TestName(),
                    inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                    inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                    inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<long[], long[], long[]>.Create<SimpleSubtractionLongSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                    inputDataContainer.GetData<long>(TypeConfig.DataLong1),
                    inputDataContainer.GetData<long>(TypeConfig.DataLong1),
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