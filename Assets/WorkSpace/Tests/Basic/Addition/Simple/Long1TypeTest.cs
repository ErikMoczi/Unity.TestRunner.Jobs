﻿using TestCase.Basic.Addition.Simple;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Addition.Simple
{
    public sealed class Long1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Long1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(long), DataConfig.DataLong1),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<long>, NativeArray<long>, NativeArray<long>>.Run<SimpleAdditionLongJob>(
                    TestName(),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerTests<NativeArray<long>, NativeArray<long>, NativeArray<long>>
                    .Run<SimpleAdditionLongJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<long>(DataConfig.DataLong1),
                        inputDataContainer.GetData<long>(DataConfig.DataLong1),
                        inputDataContainer.GetData<long>(DataConfig.DataLong1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<long[], long[], long[]>.Run<SimpleAdditionLongPlain>(
                    TestName(),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerTests<long[], long[], long[]>.Run<SimpleAdditionLongSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
                    inputDataContainer.GetData<long>(DataConfig.DataLong1),
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