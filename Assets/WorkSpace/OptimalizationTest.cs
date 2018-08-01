using TestCase.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace WorkSpace
{
    public class OptimalizationTest : SampleGenerator
    {
        private const string TestName = nameof(OptimalizationTest);
        private const string DataInt1 = "dataInt1";

        protected override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), DataInt1)
            };
        }

        protected override IWorkWrapper[] InitWorkWrappers()
        {
            return new[]
            {
                #region UnOptimalized

                WorkerTests<int, int>.RunIJob(TestName, new UnOptimizedJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new UnOptimizedJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunINonJob(TestName, new UnOptimizedNonJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1)),

                #endregion

                #region Optimalized

                WorkerTests<int, int>.RunIJob(TestName, new FullOptimizedJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstJob(), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstReadJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstWriteJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new ReadWriteJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),

                WorkerTests<int, int>.RunIJobParallelFor(TestName, new FullOptimizedJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstJobParallelFor(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstReadJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstWriteJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new ReadWriteJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),

                #endregion
            };
        }
    }
}