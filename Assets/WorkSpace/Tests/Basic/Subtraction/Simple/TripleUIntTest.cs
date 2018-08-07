﻿using TestCase.Basic.Subtraction.Simple;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Subtraction.Simple
{
    public sealed class TripleUIntTest : SampleGenerator
    {
        private const string TestName = nameof(TripleUIntTest);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint), DataConfig.DataUInt1),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<uint, uint, uint>.RunIJob(TestName, new SimpleSubtractionUIntJob(),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint, uint, uint>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionUIntJobParallelFor(),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}