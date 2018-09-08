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
    internal sealed class Double4TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double4TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double4), TypeConfig.DataDouble4),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<double4>, NativeArray<double4>, NativeArray<double4>>
                    .Create<SimdDivisionDouble4Job>(
                        TestName(),
                        inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<double4>, NativeArray<double4>, NativeArray<double4>>
                    .Create<SimdDivisionDouble4JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                        inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<double4[], double4[], double4[]>.Create<SimdDivisionDouble4Plain>(
                    TestName(),
                    inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<double4[], double4[], double4[]>.Create<SimdDivisionDouble4SystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
                    inputDataContainer.GetData<double4>(TypeConfig.DataDouble4),
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