using TestCase.Optimization;
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

namespace WorkSpace.Tests.Optimization
{
    internal sealed class UnOptimizationTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UnOptimizationTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float), TypeConfig.DataFloat1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<UnOptimizedJob>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJob(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<UnOptimizedJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(false),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<float[], float[]>.Create<UnOptimizedPlain>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<float[], float[]>.Create<UnOptimizedSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    inputDataContainer.GetData<float>(TypeConfig.DataFloat1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
            };
        }
    }
}