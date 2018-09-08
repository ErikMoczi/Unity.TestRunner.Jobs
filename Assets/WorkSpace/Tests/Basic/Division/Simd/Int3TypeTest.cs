using TestCase.Basic.Division.Simd;
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

namespace WorkSpace.Tests.Basic.Division.Simd
{
    internal sealed class Int3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int3), TypeConfig.DataInt3),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<int3>, NativeArray<int3>, NativeArray<int3>>.Create<SimdDivisionInt3Job>(
                    TestName(),
                    inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                    inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                    inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<int3>, NativeArray<int3>, NativeArray<int3>>
                    .Create<SimdDivisionInt3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                        inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                        inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<int3[], int3[], int3[]>.Create<SimdDivisionInt3Plain>(
                    TestName(),
                    inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                    inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                    inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<int3[], int3[], int3[]>.Create<SimdDivisionInt3SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                    inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
                    inputDataContainer.GetData<int3>(TypeConfig.DataInt3),
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