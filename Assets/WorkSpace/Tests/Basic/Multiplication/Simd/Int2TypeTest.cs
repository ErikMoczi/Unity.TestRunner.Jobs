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
    internal sealed class Int2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int2), TypeConfig.DataInt2),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<int2>, NativeArray<int2>, NativeArray<int2>>
                    .Create<SimdMultiplicationInt2Job>(
                        TestName(),
                        inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                        inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                        inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<int2>, NativeArray<int2>, NativeArray<int2>>
                    .Create<SimdMultiplicationInt2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                        inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                        inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<int2[], int2[], int2[]>.Create<SimdMultiplicationInt2Plain>(
                    TestName(),
                    inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                    inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                    inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<int2[], int2[], int2[]>.Create<SimdMultiplicationInt2SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                    inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
                    inputDataContainer.GetData<int2>(TypeConfig.DataInt2),
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