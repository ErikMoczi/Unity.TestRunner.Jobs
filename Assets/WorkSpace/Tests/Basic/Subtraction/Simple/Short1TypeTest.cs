﻿using TestCase.Basic.Subtraction.Simple;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;
using DataConfig = WorkSpace.Tests.Base.DataConfig;

namespace WorkSpace.Tests.Basic.Subtraction.Simple
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

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<short>, NativeArray<short>, NativeArray<short>>
                    .Create<SimpleSubtractionShortJob>(
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
                WorkerFactory<NativeArray<short>, NativeArray<short>, NativeArray<short>>
                    .Create<SimpleSubtractionShortJobParallelFor>(
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
                WorkerFactory<short[], short[], short[]>.Create<SimpleSubtractionShortPlain>(
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
                WorkerFactory<short[], short[], short[]>.Create<SimpleSubtractionShortSystemParallelFor>(
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