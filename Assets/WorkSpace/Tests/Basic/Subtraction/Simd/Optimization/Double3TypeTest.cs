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
    internal sealed class Double3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double3), TypeConfig.DataDouble3),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<double3>, NativeArray<double3>, NativeArray<double3>>
                    .Create<SimdSubtractionOptimizationDouble3Job>(
                        TestName(),
                        inputDataContainer.GetData<double3>(TypeConfig.DataDouble3),
                        inputDataContainer.GetData<double3>(TypeConfig.DataDouble3),
                        inputDataContainer.GetData<double3>(TypeConfig.DataDouble3),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<double3>, NativeArray<double3>, NativeArray<double3>>
                    .Create<SimdSubtractionOptimizationDouble3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double3>(TypeConfig.DataDouble3),
                        inputDataContainer.GetData<double3>(TypeConfig.DataDouble3),
                        inputDataContainer.GetData<double3>(TypeConfig.DataDouble3),
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