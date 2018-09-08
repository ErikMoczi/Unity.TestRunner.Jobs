using TestCase.Basic.Subtraction.Simple;
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

namespace WorkSpace.Tests.Basic.Subtraction.Simple
{
    public sealed class Double1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Double1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(double), DataConfig.DataDouble1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<double>, NativeArray<double>, NativeArray<double>>
                    .Create<SimpleSubtractionDoubleJob>(
                        TestName(),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<double>, NativeArray<double>, NativeArray<double>>
                    .Create<SimpleSubtractionDoubleJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<double[], double[], double[]>.Create<SimpleSubtractionDoublePlain>(
                    TestName(),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<double[], double[], double[]>.Create<SimpleSubtractionDoubleSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
                    inputDataContainer.GetData<double>(DataConfig.DataDouble1),
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