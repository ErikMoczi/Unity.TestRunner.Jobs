using TestCase.Basic.Addition.Simple.Optimization;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Provider.Containers;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Tests.Basic.Addition.Simple.Optimization
{
    internal sealed class Double1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double), TypeConfig.DataDouble1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<double>, NativeArray<double>, NativeArray<double>>
                    .Create<SimpleAdditionOptimizationDoubleJob>(
                        TestName(),
                        inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                        inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                        inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<double>, NativeArray<double>, NativeArray<double>>
                    .Create<SimpleAdditionOptimizationDoubleJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                        inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                        inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
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