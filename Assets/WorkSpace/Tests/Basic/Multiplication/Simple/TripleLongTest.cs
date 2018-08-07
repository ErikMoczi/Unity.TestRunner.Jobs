using TestCase.Basic.Multiplication.Simple;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Multiplication.Simple
{
    public sealed class TripleLongTest : SampleGenerator
    {
        private const string TestName = nameof(TripleLongTest);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(long), DataConfig.DataLong1),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleMultiplicationLongJob(),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationLongJobParallelFor(),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}