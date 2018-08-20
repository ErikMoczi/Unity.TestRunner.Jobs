using TestCase.Basic.Operators.And.Simd;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Operators.And.Simd
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
                WorkerTests<bool2, bool2, bool2>.RunIJob(TestName, new SimdOperatorsAndBool2Job(),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<bool2, bool2, bool2>.RunIJobParallelFor(TestName, new SimdOperatorsAndBool2JobParallelFor(),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}