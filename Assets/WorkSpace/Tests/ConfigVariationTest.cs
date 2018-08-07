using TestCase.Basic.Addition.Simple;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests
{
    public class ConfigVariationTest : SampleGenerator
    {
        private const string TestName = nameof(ConfigVariationTest);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), DataConfig.DataInt1),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                #region Allocator

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Temp)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Temp, true)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.TempJob)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.TempJob, true)),

                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Temp, false, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Temp, true, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.TempJob, false, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.TempJob, true, 64)),

                #endregion

                #region BatchCount

                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 2)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 4)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 8)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 16)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 32)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 128)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 256)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 512)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, 1024)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, false, dataSize)),

                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 2)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 4)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 8)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 16)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 32)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 128)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 256)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 512)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 1024)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, dataSize)),

                #endregion
            };
        }
    }
}