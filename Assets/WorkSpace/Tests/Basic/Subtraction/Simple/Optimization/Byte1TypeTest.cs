using TestCase.Basic.Subtraction.Simple.Optimization;
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

namespace WorkSpace.Tests.Basic.Subtraction.Simple.Optimization
{
    internal sealed class Byte1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(Byte1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(byte), TypeConfig.DataByte1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<byte>, NativeArray<byte>, NativeArray<byte>>
                    .Create<SimpleSubtractionOptimizationByteJob>(
                        TestName(),
                        inputDataContainer.GetData<byte>(TypeConfig.DataByte1),
                        inputDataContainer.GetData<byte>(TypeConfig.DataByte1),
                        inputDataContainer.GetData<byte>(TypeConfig.DataByte1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<byte>, NativeArray<byte>, NativeArray<byte>>
                    .Create<SimpleSubtractionOptimizationByteJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<byte>(TypeConfig.DataByte1),
                        inputDataContainer.GetData<byte>(TypeConfig.DataByte1),
                        inputDataContainer.GetData<byte>(TypeConfig.DataByte1),
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