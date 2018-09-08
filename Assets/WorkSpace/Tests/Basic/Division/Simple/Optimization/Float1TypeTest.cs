using TestCase.Basic.Division.Simple.Optimization;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Tests.Base;
using DataConfig = WorkSpace.Tests.Base.DataConfig;

namespace WorkSpace.Tests.Basic.Division.Simple.Optimization
{
    public sealed class Float1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Float1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float), DataConfig.DataFloat1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<float>, NativeArray<float>, NativeArray<float>>
                    .Create<SimpleDivisionOptimizationFloatJob>(
                        TestName(),
                        inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                        inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                        inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<float>, NativeArray<float>, NativeArray<float>>
                    .Create<SimpleDivisionOptimizationFloatJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                        inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                        inputDataContainer.GetData<float>(DataConfig.DataFloat1),
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