using TestCase.Basic.Operators.Inequality.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Operators.Inequality.Simd.Optimalization
{
    public sealed class TripleTypeBool2Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeBool2Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(bool2), DataConfig.DataBool2),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<bool2, bool2, bool2>.RunIJob(TestName, new SimdOperatorsInequalityOptimalizationBool2Job(),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<bool2, bool2, bool2>.RunIJobParallelFor(TestName,
                    new SimdOperatorsInequalityOptimalizationBool2JobParallelFor(),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}