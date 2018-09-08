using TestCase.Basic.Addition.Simd.Optimization;
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

namespace WorkSpace.Tests.Basic.Addition.Simd.Optimization
{
    public sealed class Double2TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double2TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double2), DataConfig.DataDouble2),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<double2>, NativeArray<double2>, NativeArray<double2>>
                    .Create<SimdAdditionOptimizationDouble2Job>(
                        TestName(),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<double2>, NativeArray<double2>, NativeArray<double2>>
                    .Create<SimdAdditionOptimizationDouble2JobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
                        inputDataContainer.GetData<double2>(DataConfig.DataDouble2),
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