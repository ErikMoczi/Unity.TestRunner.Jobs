using TestCase.BurstOptions;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace WorkSpace
{
    public class BurstOptionsTest : SampleGenerator
    {
        private const string TestName = nameof(BurstOptionsTest);
        private const string DataInt1 = "DataInt1";
        private const string DataFloat1 = "DataFloat1";

        protected override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), DataInt1),
                new SampleConfig(typeof(float), DataFloat1)
            };
        }

        protected override IWorkWrapper[] InitWorkWrappers()
        {
            return new[]
            {
                #region CompileSynchronously

                WorkerTests<int, int>.RunIJob(TestName, new BurstCompileSynchronouslyTrueJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstCompileSynchronouslyTrueJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstCompileSynchronouslyFalseJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstCompileSynchronouslyFalseJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent, true)),


                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstCompileSynchronouslyTrueJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstCompileSynchronouslyTrueJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstCompileSynchronouslyFalseJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstCompileSynchronouslyFalseJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),

                #endregion

                #region Support

                WorkerTests<float, float>.RunIJob(TestName, new BurstSupportRelaxedJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstSupportRelaxedJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstSupportStrictJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstSupportStrictJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent, true)),

                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstSupportRelaxedJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstSupportRelaxedJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstSupportStrictJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstSupportStrictJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),

                #endregion

                #region Accuracy

                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyStdJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyStdJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyLowJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyLowJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyMedJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyMedJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyHighJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyHighJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent, true)),

                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyStdJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyStdJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyLowJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyLowJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyMedJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyMedJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyHighJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyHighJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),

                #endregion
            };
        }
    }
}