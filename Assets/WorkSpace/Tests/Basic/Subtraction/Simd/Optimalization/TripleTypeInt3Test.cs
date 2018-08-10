using TestCase.Basic.Subtraction.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simd.Optimalization
{
    public sealed class TripleTypeInt3Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeInt3Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int3), DataConfig.DataInt3),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<int3, int3, int3>.RunIJob(TestName, new SimdSubtractionOptimalizationInt3Job(),
                    inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                    inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                    inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int3, int3, int3>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationInt3JobParallelFor(),
                    inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                    inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                    inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}