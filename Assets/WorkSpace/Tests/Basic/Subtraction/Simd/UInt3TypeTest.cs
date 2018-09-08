﻿using TestCase.Basic.Subtraction.Simd;
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

namespace WorkSpace.Tests.Basic.Subtraction.Simd
{
    public sealed class UInt3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint3), DataConfig.DataUInt3),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<uint3>, NativeArray<uint3>, NativeArray<uint3>>
                    .Create<SimdSubtractionUInt3Job>(
                        TestName(),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<uint3>, NativeArray<uint3>, NativeArray<uint3>>
                    .Create<SimdSubtractionUInt3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<uint3[], uint3[], uint3[]>.Create<SimdSubtractionUInt3Plain>(
                    TestName(),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<uint3[], uint3[], uint3[]>.Create<SimdSubtractionUInt3SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
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