using TestCase.Basic.Subtraction.Simd.Optimization;
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

namespace WorkSpace.Tests.Basic.Subtraction.Simd.Optimization
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
                WorkerFactory<NativeArray<int4>, NativeArray<int4>, NativeArray<int4>>
                    .Create<SimdSubtractionOptimizationInt4Job>(
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
                    .Create<SimdSubtractionOptimizationInt4JobParallelFor>(
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
            };
        }
    }
}