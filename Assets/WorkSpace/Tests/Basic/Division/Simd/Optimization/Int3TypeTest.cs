using TestCase.Basic.Division.Simd.Optimization;
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

namespace WorkSpace.Tests.Basic.Division.Simd.Optimization
{
    public sealed class Int3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int3), DataConfig.DataInt3),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<int3>, NativeArray<int3>, NativeArray<int3>>
                    .Run<SimdDivisionOptimizationInt3Job>(
                        TestName(),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<int3>, NativeArray<int3>, NativeArray<int3>>
                    .Run<SimdDivisionOptimizationInt3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
                        inputDataContainer.GetData<int3>(DataConfig.DataInt3),
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