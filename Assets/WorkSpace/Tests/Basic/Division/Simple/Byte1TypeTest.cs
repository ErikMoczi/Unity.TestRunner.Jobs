using TestCase.Basic.Division.Simple;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Division.Simple
{
    public sealed class Byte1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Byte1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(byte), DataConfig.DataByte1),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<byte>, NativeArray<byte>, NativeArray<byte>>.Run<SimpleDivisionByteJob>(
                    TestName(),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<byte>, NativeArray<byte>, NativeArray<byte>>
                    .Run<SimpleDivisionByteJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                        inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                        inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<byte[], byte[], byte[]>.Run<SimpleDivisionBytePlain>(
                    TestName(),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<byte[], byte[], byte[]>.Run<SimpleDivisionByteSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
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