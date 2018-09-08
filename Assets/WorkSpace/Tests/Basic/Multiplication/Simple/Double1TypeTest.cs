using TestCase.Basic.Multiplication.Simple;
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

namespace WorkSpace.Tests.Basic.Multiplication.Simple
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
                    .Create<SimpleMultiplicationDoubleJob>(
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
                    .Create<SimpleMultiplicationDoubleJobParallelFor>(
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
                WorkerFactory<double[], double[], double[]>.Create<SimpleMultiplicationDoublePlain>(
                    TestName(),
                    inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                    inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                    inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<double[], double[], double[]>.Create<SimpleMultiplicationDoubleSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                    inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                    inputDataContainer.GetData<double>(TypeConfig.DataDouble1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
            };
        }
    }
}