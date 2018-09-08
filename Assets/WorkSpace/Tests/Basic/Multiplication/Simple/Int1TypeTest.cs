using TestCase.Basic.Multiplication.Simple;
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

namespace WorkSpace.Tests.Basic.Multiplication.Simple
{
    public sealed class Int1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), DataConfig.DataInt1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<int>, NativeArray<int>, NativeArray<int>>.Create<SimpleMultiplicationIntJob>(
                    TestName(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<int>, NativeArray<int>, NativeArray<int>>
                    .Create<SimpleMultiplicationIntJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int>(DataConfig.DataInt1),
                        inputDataContainer.GetData<int>(DataConfig.DataInt1),
                        inputDataContainer.GetData<int>(DataConfig.DataInt1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<int[], int[], int[]>.Create<SimpleMultiplicationIntPlain>(
                    TestName(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<int[], int[], int[]>.Create<SimpleMultiplicationIntSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
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