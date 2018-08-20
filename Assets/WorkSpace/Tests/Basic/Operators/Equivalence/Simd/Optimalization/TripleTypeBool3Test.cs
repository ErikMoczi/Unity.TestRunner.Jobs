using TestCase.Basic.Operators.Equivalence.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Operators.Equivalence.Simd.Optimalization
{
    public sealed class TripleTypeBool3Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeBool3Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(bool3), DataConfig.DataBool3),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<bool3, bool3, bool3>.RunIJob(TestName, new SimdOperatorsEquivalenceOptimalizationBool3Job(),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<bool3, bool3, bool3>.RunIJobParallelFor(TestName,
                    new SimdOperatorsEquivalenceOptimalizationBool3JobParallelFor(),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}