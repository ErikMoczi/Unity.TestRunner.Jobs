using TestCase.Basic.Addition.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Addition.Simd.Optimalization
{
    public sealed class TripleTypeFloat2Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeFloat2Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float2), DataConfig.DataFloat2),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<float2, float2, float2>.RunIJob(TestName, new SimdAdditionOptimalizationFloat2Job(),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float2, float2, float2>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationFloat2JobParallelFor(),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    inputDataContainer.GetData<float2>(DataConfig.DataFloat2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}