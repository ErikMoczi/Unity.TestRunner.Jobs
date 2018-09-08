﻿using TestCase.Basic.Multiplication.Simd;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Provider.Containers;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Tests.Basic.Multiplication.Simd
{
    internal sealed class UInt2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint2), TypeConfig.DataUInt2),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<uint2>, NativeArray<uint2>, NativeArray<uint2>>
                    .Create<SimdMultiplicationUInt2Job>(
                        TestName(),
                        inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<uint2>, NativeArray<uint2>, NativeArray<uint2>>
                    .Create<SimdMultiplicationUInt2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<uint2[], uint2[], uint2[]>.Create<SimdMultiplicationUInt2Plain>(
                    TestName(),
                    inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<uint2[], uint2[], uint2[]>.Create<SimdMultiplicationUInt2SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
                    inputDataContainer.GetData<uint2>(TypeConfig.DataUInt2),
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