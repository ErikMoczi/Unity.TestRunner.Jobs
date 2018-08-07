﻿using TestCase.Basic.Division.Simd;
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
    public sealed class TripleUInt4Test : SampleGenerator
    {
        private const string TestName = nameof(TripleUInt4Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint4), DataConfig.DataUInt4),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<uint4, uint4, uint4>.RunIJob(TestName, new SimdDivisionUInt4Job(),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint4, uint4, uint4>.RunIJobParallelFor(TestName,
                    new SimdDivisionUInt4JobParallelFor(),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}