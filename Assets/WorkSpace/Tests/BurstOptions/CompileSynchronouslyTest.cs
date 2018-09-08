﻿using TestCase.BurstOptions;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Provider.Containers;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Tests.BurstOptions
{
    internal sealed class CompileSynchronouslyTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(CompileSynchronouslyTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float), TypeConfig.DataFloat1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                #region IJob

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstCompileSynchronouslyTrueJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstCompileSynchronouslyTrueJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstCompileSynchronouslyFalseJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<BurstCompileSynchronouslyFalseJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),

                #endregion

                #region IJobParallelFor

                WorkerFactory<NativeArray<float>, NativeArray<float>>
                    .Create<BurstCompileSynchronouslyTrueJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>
                    .Create<BurstCompileSynchronouslyTrueJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        new WorkConfigIJobParallelFor(false),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>
                    .Create<BurstCompileSynchronouslyFalseJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>
                    .Create<BurstCompileSynchronouslyFalseJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        new WorkConfigIJobParallelFor(false),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),

                #endregion
            };
        }
    }
}