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
    public sealed class UInt4TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt4TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint4), DataConfig.DataUInt4),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<uint4>, NativeArray<uint4>, NativeArray<uint4>>
                    .Create<SimdAdditionOptimizationUInt4Job>(
                        TestName(),
                        inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                        inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                        inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<uint4>, NativeArray<uint4>, NativeArray<uint4>>
                    .Create<SimdAdditionOptimizationUInt4JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                        inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
                        inputDataContainer.GetData<uint4>(DataConfig.DataUInt4),
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