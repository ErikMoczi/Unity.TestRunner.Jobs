using TestCase.Basic.Multiplication.Simd;
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
    internal sealed class UInt3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint3), TypeConfig.DataUInt3),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<uint3>, NativeArray<uint3>, NativeArray<uint3>>
                    .Create<SimdMultiplicationUInt3Job>(
                        TestName(),
                        inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<uint3>, NativeArray<uint3>, NativeArray<uint3>>
                    .Create<SimdMultiplicationUInt3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<uint3[], uint3[], uint3[]>.Create<SimdMultiplicationUInt3Plain>(
                    TestName(),
                    inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<uint3[], uint3[], uint3[]>.Create<SimdMultiplicationUInt3SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
                    inputDataContainer.GetData<uint3>(TypeConfig.DataUInt3),
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