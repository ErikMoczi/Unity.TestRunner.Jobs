﻿using TestCase.Basic.Addition.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Addition.Simd.Optimalization
{
    public sealed class TripleTypeUInt3Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeUInt3Test);

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
                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdAdditionOptimalizationUInt3Job(),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationUInt3JobParallelFor(),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}