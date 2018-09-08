﻿using TestCase.Basic.Division.Simple.Optimization;
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

namespace WorkSpace.Tests.Basic.Division.Simple.Optimization
{
    internal sealed class Float1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Float1TypeTest);
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
                WorkerFactory<NativeArray<float>, NativeArray<float>, NativeArray<float>>
                    .Create<SimpleDivisionOptimizationFloatJob>(
                        TestName(),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<float>, NativeArray<float>, NativeArray<float>>
                    .Create<SimpleDivisionOptimizationFloatJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
            };
        }
    }
}