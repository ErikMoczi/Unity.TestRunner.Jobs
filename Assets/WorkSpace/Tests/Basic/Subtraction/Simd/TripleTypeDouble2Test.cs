using TestCase.Basic.Subtraction.Simd;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simd
{
    public sealed class TripleTypeDouble2Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeDouble2Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double2), DataConfig.DataDouble2),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<double2, double2, double2>.RunIJob(TestName, new SimdSubtractionDouble2Job(),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<double2, double2, double2>.RunIJobParallelFor(TestName, new SimdSubtractionDouble2JobParallelFor(),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}