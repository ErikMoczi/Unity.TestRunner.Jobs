﻿using TestCase.Basic.Multiplication.Simple;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Multiplication.Simple
{
    public sealed class Short1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Short1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(short), DataConfig.DataShort1),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<short>, NativeArray<short>, NativeArray<short>>
                    .Run<SimpleMultiplicationShortJob>(
                        TestName(),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<short>, NativeArray<short>, NativeArray<short>>
                    .Run<SimpleMultiplicationShortJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        inputDataContainer.GetData<short>(DataConfig.DataShort1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<short[], short[], short[]>.Run<SimpleMultiplicationShortPlain>(
                    TestName(),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<short[], short[], short[]>.Run<SimpleMultiplicationShortSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    inputDataContainer.GetData<short>(DataConfig.DataShort1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
            };
        }
    }
}