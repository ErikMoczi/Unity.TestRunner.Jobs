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
    public sealed class UInt3TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt3TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint3), DataConfig.DataUInt3),
            };
        }

        public override ITestFacade[] InitTestFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<NativeArray<uint3>, NativeArray<uint3>, NativeArray<uint3>>
                    .Run<SimdMultiplicationOptimizationUInt3Job>(
                        TestName(),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerTests<NativeArray<uint3>, NativeArray<uint3>, NativeArray<uint3>>
                    .Run<SimdMultiplicationOptimizationUInt3JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
                        inputDataContainer.GetData<uint3>(DataConfig.DataUInt3),
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