using TestCase.Basic.Multiplication.Simd.Optimization;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;
using DataConfig = WorkSpace.Tests.Base.DataConfig;

namespace WorkSpace.Tests.Basic.Multiplication.Simd.Optimization
{
    public sealed class UInt2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint2), DataConfig.DataUInt2),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<uint2>, NativeArray<uint2>, NativeArray<uint2>>
                    .Create<SimdMultiplicationOptimizationUInt2Job>(
                        TestName(),
                        inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<uint2>, NativeArray<uint2>, NativeArray<uint2>>
                    .Create<SimdMultiplicationOptimizationUInt2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
                        inputDataContainer.GetData<uint2>(DataConfig.DataUInt2),
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