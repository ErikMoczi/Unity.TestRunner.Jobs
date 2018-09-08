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
    public sealed class UInt1TypeTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(UInt1TypeTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(uint), DataConfig.DataUInt1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerFactory<NativeArray<uint>, NativeArray<uint>, NativeArray<uint>>
                    .Create<SimpleDivisionOptimizationUIntJob>(
                        TestName(),
                        inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                        inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                        inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                        new WorkConfigIJob(),
                        new IDataConfig[]
                        {
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                            new DataConfigUnityCollection(Allocator.Persistent),
                        }
                    ),
                WorkerFactory<NativeArray<uint>, NativeArray<uint>, NativeArray<uint>>
                    .Create<SimpleDivisionOptimizationUIntJobParallelFor>(
                        TestName(),
                        inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                        inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
                        inputDataContainer.GetData<uint>(DataConfig.DataUInt1),
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