using TestCase.Basic.Subtraction.Simd;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simd
{
    public sealed class TripleUInt3Test : SampleGenerator
    {
        private const string TestName = nameof(TripleUInt3Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint3), DataConfig.DataUInt3),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdSubtractionUInt3Job(),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName,
                    new SimdSubtractionUInt3JobParallelFor(),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}