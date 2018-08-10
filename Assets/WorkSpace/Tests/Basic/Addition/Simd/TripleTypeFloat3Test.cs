using TestCase.Basic.Addition.Simd;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Addition.Simd
{
    public sealed class TripleTypeFloat3Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeFloat3Test);

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
                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdAdditionFloat3Job(),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName, new SimdAdditionFloat3JobParallelFor(),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    inputDataContainer.GetData<float3>(DataConfig.DataFloat3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}