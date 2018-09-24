using TestCase.Custom;
using TestCase.DataStructure;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.DataType;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using WorkSpace.Provider.Containers;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Tests.Custom
{
    internal sealed class AddTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(AddTest);
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
                WorkerFactory<int[]>.Create<AddPlain>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<NativeArray<int>>.Create<AddJob>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeConcurrentIntArray.Concurrent>.Create<AddJobParallelForConcurrentFirstElement>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeConcurrentIntArray.Concurrent>.Create<AddJobParallelForConcurrentIndex>(
                    TestName(),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
            };
        }
    }
}