using TestCase.Basic.Division.Simple;
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

namespace WorkSpace.Tests.Basic.Division.Simple
{
    internal sealed class Int1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Int1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), TypeConfig.DataInt1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<int>, NativeArray<int>, NativeArray<int>>.Create<SimpleDivisionIntJob>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<int>, NativeArray<int>, NativeArray<int>>
                    .Create<SimpleDivisionIntJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                        inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                        inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                        new WorkConfigIJobParallelFor(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<int[], int[], int[]>.Create<SimpleDivisionIntPlain>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<int[], int[], int[]>.Create<SimpleDivisionIntSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
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