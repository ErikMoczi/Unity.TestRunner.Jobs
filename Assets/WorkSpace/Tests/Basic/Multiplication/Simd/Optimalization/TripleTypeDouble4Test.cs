using TestCase.Basic.Multiplication.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Multiplication.Simd.Optimalization
{
    public sealed class TripleTypeDouble4Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeDouble4Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double4), DataConfig.DataDouble4),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<double4, double4, double4>.RunIJob(TestName, new SimdMultiplicationOptimalizationDouble4Job(),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<double4, double4, double4>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationDouble4JobParallelFor(),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}