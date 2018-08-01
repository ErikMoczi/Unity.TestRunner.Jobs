using TestCase.Basic.Addition;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using UnityEngine;

namespace WorkSpace
{
    public class ConfigVariationTest : SampleGenerator
    {
        private const string TestName = nameof(ConfigVariationTest);
        private const string DataInt1 = "dataInt1";

        protected override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), DataInt1),
            };
        }

        protected override IWorkWrapper[] InitWorkWrappers()
        {
            Debug.Log(SystemInfo.processorCount);
            return new[]
            {
                #region Allocator

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Temp)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Temp, true)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.TempJob)),
                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.TempJob, true)),

                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 64, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Temp, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Temp, 64, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.TempJob, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.TempJob, 64, true)),

                #endregion

                #region BatchCount

                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 2)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 4)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 8)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 16)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 32)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 64)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 128)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 256)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 512)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 1024)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, DataSize)),

                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 2, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 4, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 8, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 16, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 32, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 64, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 128, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 256, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 512, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, 1024, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, DataSize, true)),

                #endregion
            };
        }
    }
}