using TestCase.Basic.Division.Simd;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Division.Simd
{
    public sealed class TripleFloat3Test : SampleGenerator
    {
        private const string TestName = nameof(TripleFloat3Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float3), DataConfig.DataFloat3),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdDivisionFloat3Job(),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName,
                    new SimdDivisionFloat3JobParallelFor(),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}