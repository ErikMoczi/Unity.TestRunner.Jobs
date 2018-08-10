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
    public sealed class TripleTypeInt2Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeInt2Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int2), DataConfig.DataInt2),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<int2, int2, int2>.RunIJob(TestName, new SimdDivisionOptimalizationInt2Job(),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int2, int2, int2>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationInt2JobParallelFor(),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}