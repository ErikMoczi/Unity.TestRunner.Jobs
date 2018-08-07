using TestCase.Basic.Subtraction.Simple.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simple.Optimalization
{
    public sealed class TripleByteTest : SampleGenerator
    {
        private const string TestName = nameof(TripleByteTest);

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
                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleSubtractionOptimalizationByteJob(),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionOptimalizationByteJobParallelFor(),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    inputDataContainer.GetData<byte>(DataConfig.DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}