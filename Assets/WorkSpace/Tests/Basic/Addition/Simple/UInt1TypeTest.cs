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
    internal sealed class UInt1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint), TypeConfig.DataUInt1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<uint>, NativeArray<uint>, NativeArray<uint>>.Create<SimpleAdditionUIntJob>(
                    TestName(),
                    inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<uint>, NativeArray<uint>, NativeArray<uint>>
                    .Create<SimpleAdditionUIntJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                        inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                        inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<uint[], uint[], uint[]>.Create<SimpleAdditionUIntPlain>(
                    TestName(),
                    inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<uint[], uint[], uint[]>.Create<SimpleAdditionUIntSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(TypeConfig.DataUInt1),
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