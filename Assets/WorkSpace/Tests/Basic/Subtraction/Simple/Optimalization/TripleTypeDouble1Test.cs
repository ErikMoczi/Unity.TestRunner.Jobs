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
    public sealed class TripleTypeDouble1Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeDouble1Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double), DataConfig.DataDouble1),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<double, double, double>.RunIJob(TestName, new SimpleSubtractionOptimalizationDoubleJob(),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<double, double, double>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionOptimalizationDoubleJobParallelFor(),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}