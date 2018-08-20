using TestCase.Basic.Division.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Division.Simd.Optimalization
{
    public sealed class TripleTypeDouble3Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeDouble3Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double3), DataConfig.DataDouble3),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<double3, double3, double3>.RunIJob(TestName, new SimdDivisionOptimalizationDouble3Job(),
                    inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                    inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                    inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<double3, double3, double3>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationDouble3JobParallelFor(),
                    inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                    inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                    inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}