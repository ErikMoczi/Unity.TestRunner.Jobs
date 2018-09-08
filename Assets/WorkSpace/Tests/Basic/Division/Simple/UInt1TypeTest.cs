using TestCase.Basic.Division.Simple;
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

namespace WorkSpace.Tests.Basic.Division.Simple
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
                WorkerFactory<NativeArray<uint>, NativeArray<uint>, NativeArray<uint>>.Create<SimpleDivisionUIntJob>(
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
                    .Create<SimpleDivisionUIntJobParallelFor>(
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
                WorkerFactory<uint[], uint[], uint[]>.Create<SimpleDivisionUIntPlain>(
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
                WorkerFactory<uint[], uint[], uint[]>.Create<SimpleDivisionUIntSystemParallelFor>(
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