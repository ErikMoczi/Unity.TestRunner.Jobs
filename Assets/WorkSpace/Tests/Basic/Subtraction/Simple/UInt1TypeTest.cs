using TestCase.Basic.Subtraction.Simple;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simple
{
    public sealed class UInt1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint), DataConfig.DataUInt1),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<uint>, NativeArray<uint>, NativeArray<uint>>.Run<SimpleSubtractionUIntJob>(
                    TestName(),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<uint>, NativeArray<uint>, NativeArray<uint>>
                    .Run<SimpleSubtractionUIntJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                        inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                        inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<uint[], uint[], uint[]>.Run<SimpleSubtractionUIntPlain>(
                    TestName(),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<uint[], uint[], uint[]>.Run<SimpleSubtractionUIntSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
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