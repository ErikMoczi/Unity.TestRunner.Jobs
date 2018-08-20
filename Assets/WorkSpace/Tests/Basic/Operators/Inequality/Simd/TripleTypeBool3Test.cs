using TestCase.Basic.Operators.Inequality.Simd;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Operators.Inequality.Simd
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
                WorkerTests<bool3, bool3, bool3>.RunIJob(TestName, new SimdOperatorsInequalityBool3Job(),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<bool3, bool3, bool3>.RunIJobParallelFor(TestName, new SimdOperatorsInequalityBool3JobParallelFor(),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    inputDataContainer.GetData<bool3>(DataConfig.DataBool3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}