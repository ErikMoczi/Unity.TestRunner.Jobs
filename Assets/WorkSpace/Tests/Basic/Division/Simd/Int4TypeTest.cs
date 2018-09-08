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
    internal sealed class Int4TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int4TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int4), TypeConfig.DataInt4),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<int4>, NativeArray<int4>, NativeArray<int4>>.Create<SimdDivisionInt4Job>(
                    TestName(),
                    inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                    inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                    inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<int4>, NativeArray<int4>, NativeArray<int4>>
                    .Create<SimdDivisionInt4JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                        inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                        inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<int4[], int4[], int4[]>.Create<SimdDivisionInt4Plain>(
                    TestName(),
                    inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                    inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                    inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<int4[], int4[], int4[]>.Create<SimdDivisionInt4SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                    inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
                    inputDataContainer.GetData<int4>(TypeConfig.DataInt4),
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