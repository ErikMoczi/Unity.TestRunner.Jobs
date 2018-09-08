﻿using TestCase.Basic.Division.Simd.Optimization;
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

namespace WorkSpace.Tests.Basic.Division.Simd.Optimization
{
    public sealed class Double4TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double4TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double4), DataConfig.DataDouble4),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<double4>, NativeArray<double4>, NativeArray<double4>>
                    .Create<SimdDivisionOptimizationDouble4Job>(
                        TestName(),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<double4>, NativeArray<double4>, NativeArray<double4>>
                    .Create<SimdDivisionOptimizationDouble4JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(DataConfig.DataDouble4),
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