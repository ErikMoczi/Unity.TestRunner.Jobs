﻿using TestCase.Basic.Division.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Division.Simd.Optimalization
{
    public sealed class TripleTypeFloat4Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeFloat4Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float4), DataConfig.DataFloat4),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<float4, float4, float4>.RunIJob(TestName, new SimdDivisionOptimalizationFloat4Job(),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float4, float4, float4>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationFloat4JobParallelFor(),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    inputDataContainer.GetData<float4>(DataConfig.DataFloat4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}