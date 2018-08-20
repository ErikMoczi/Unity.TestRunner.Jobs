using TestCase.Basic.Operators.Xor.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Operators.Xor.Simd.Optimalization
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
                WorkerTests<bool2, bool2, bool2>.RunIJob(TestName, new SimdOperatorsXorOptimalizationBool2Job(),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<bool2, bool2, bool2>.RunIJobParallelFor(TestName,
                    new SimdOperatorsXorOptimalizationBool2JobParallelFor(),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    inputDataContainer.GetData<bool2>(DataConfig.DataBool2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}