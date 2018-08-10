using TestCase.Basic.Addition.Simple;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Addition.Simple
{
    public sealed class TripleTypeByte1Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeByte1Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(byte), DataConfig.DataByte1),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleAdditionByteJob(),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName,
                    new SimpleAdditionByteJobParallelFor(),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
                WorkerTests<byte, byte, byte>.RunINonJob(TestName, new SimpleAdditionByteNonJob(),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1)),
            };
        }
    }
}