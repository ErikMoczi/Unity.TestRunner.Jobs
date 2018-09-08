using TestCase.DataStructure;
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

namespace WorkSpace.Tests.DataStructure
{
    public sealed class DataStructureTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(DataStructureTest);
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
                WorkerFactory<float[], float[]>.Create<ArrayPlain>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<float[], float[]>.Create<ArraySystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),

                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<NativeArraySystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<float>, NativeArray<float>>.Create<NativeArrayPlain>(
                    TestName(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
            };
        }
    }
}