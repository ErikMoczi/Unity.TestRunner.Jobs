using TestCase.Basic.Division.Simd.Optimization;
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

namespace WorkSpace.Tests.Basic.Division.Simd.Optimization
{
    public sealed class Int2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int2), DataConfig.DataInt2),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<int2>, NativeArray<int2>, NativeArray<int2>>
                    .Create<SimdDivisionOptimizationInt2Job>(
                        TestName(),
                        inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                        inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                        inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<int2>, NativeArray<int2>, NativeArray<int2>>
                    .Create<SimdDivisionOptimizationInt2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                        inputDataContainer.GetData<int2>(DataConfig.DataInt2),
                        inputDataContainer.GetData<int2>(DataConfig.DataInt2),
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