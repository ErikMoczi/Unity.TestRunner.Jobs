using TestCase.Basic.Operators.Equivalence.Simd;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Operators.Equivalence.Simd
{
    public sealed class TripleTypeBool4Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeBool4Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(bool4), DataConfig.DataBool4),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<bool4, bool4, bool4>.RunIJob(TestName, new SimdOperatorsEquivalenceBool4Job(),
                    inputDataContainer.GetData<bool4>(DataConfig.DataBool4),
                    inputDataContainer.GetData<bool4>(DataConfig.DataBool4),
                    inputDataContainer.GetData<bool4>(DataConfig.DataBool4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<bool4, bool4, bool4>.RunIJobParallelFor(TestName, new SimdOperatorsEquivalenceBool4JobParallelFor(),
                    inputDataContainer.GetData<bool4>(DataConfig.DataBool4),
                    inputDataContainer.GetData<bool4>(DataConfig.DataBool4),
                    inputDataContainer.GetData<bool4>(DataConfig.DataBool4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}