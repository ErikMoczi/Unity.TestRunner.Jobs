using TestCase.Basic.Addition.Simple;
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

namespace WorkSpace.Tests.Basic.Addition.Simple
{
    internal sealed class Short1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Short1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(short), TypeConfig.DataShort1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<short>, NativeArray<short>, NativeArray<short>>
                    .Create<SimpleAdditionShortJob>(
                        TestName(),
                        inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                        inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                        inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<short>, NativeArray<short>, NativeArray<short>>
                    .Create<SimpleAdditionShortJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                        inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                        inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<short[], short[], short[]>.Create<SimpleAdditionShortPlain>(
                    TestName(),
                    inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                    inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                    inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<short[], short[], short[]>.Create<SimpleAdditionShortSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                    inputDataContainer.GetData<short>(TypeConfig.DataShort1),
                    inputDataContainer.GetData<short>(TypeConfig.DataShort1),
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