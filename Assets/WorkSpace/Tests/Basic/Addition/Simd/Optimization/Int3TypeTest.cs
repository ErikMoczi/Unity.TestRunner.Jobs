﻿using TestCase.Basic.Addition.Simd.Optimization;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;
using DataConfig = WorkSpace.Tests.Base.DataConfig;

namespace WorkSpace.Tests.Basic.Addition.Simd.Optimization
{
    public sealed class Int3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int3), DataConfig.DataInt3),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<int3>, NativeArray<int3>, NativeArray<int3>>
                    .Create<SimdAdditionOptimizationInt3Job>(
                        TestName(),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<int3>, NativeArray<int3>, NativeArray<int3>>
                    .Create<SimdAdditionOptimizationInt3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
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