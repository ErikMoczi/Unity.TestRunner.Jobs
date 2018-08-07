using TestCase.Basic.Subtraction.Simple;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simple
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
                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleSubtractionLongJob(),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionLongJobParallelFor(),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}