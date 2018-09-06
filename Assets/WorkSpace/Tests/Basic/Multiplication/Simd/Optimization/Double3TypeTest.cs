using TestCase.Basic.Multiplication.Simd.Optimization;
using TestRunner;
using TestRunner.Config.Data;
using TestRunner.Config.Data.Interfaces;
using TestRunner.Config.Worker;
using TestRunner.Facades;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Multiplication.Simd.Optimization
{
    public sealed class Double3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double3), DataConfig.DataDouble3),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<double3>, NativeArray<double3>, NativeArray<double3>>
                    .Run<SimdMultiplicationOptimizationDouble3Job>(
                        TestName(),
                        inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                        inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                        inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<double3>, NativeArray<double3>, NativeArray<double3>>
                    .Run<SimdMultiplicationOptimizationDouble3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                        inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
                        inputDataContainer.GetData<double3>(DataConfig.DataDouble3),
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