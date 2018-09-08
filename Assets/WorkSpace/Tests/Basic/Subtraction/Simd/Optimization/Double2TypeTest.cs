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
    internal sealed class Double2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double2), TypeConfig.DataDouble2),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<double2>, NativeArray<double2>, NativeArray<double2>>
                    .Create<SimdSubtractionOptimizationDouble2Job>(
                        TestName(),
                        inputDataContainer.GetData<double2>(TypeConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(TypeConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(TypeConfig.DataDouble2),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<double2>, NativeArray<double2>, NativeArray<double2>>
                    .Create<SimdSubtractionOptimizationDouble2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double2>(TypeConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(TypeConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(TypeConfig.DataDouble2),
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