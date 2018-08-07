using TestCase.BurstOptions;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests
{
    public class BurstOptionsTest : SampleGenerator
    {
        private const string TestName = nameof(BurstOptionsTest);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), DataConfig.DataInt1),
                new SampleConfig(typeof(float), DataConfig.DataFloat1)
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                #region CompileSynchronously

                WorkerTests<int, int>.RunIJob(TestName, new BurstCompileSynchronouslyTrueJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstCompileSynchronouslyTrueJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstCompileSynchronouslyFalseJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstCompileSynchronouslyFalseJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),


                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstCompileSynchronouslyTrueJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstCompileSynchronouslyTrueJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstCompileSynchronouslyFalseJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstCompileSynchronouslyFalseJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),

                #endregion

                #region Support

                WorkerTests<float, float>.RunIJob(TestName, new BurstSupportRelaxedJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstSupportRelaxedJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstSupportStrictJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstSupportStrictJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),

                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstSupportRelaxedJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstSupportRelaxedJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstSupportStrictJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstSupportStrictJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),

                #endregion

                #region Accuracy

                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyStdJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyStdJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyLowJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyLowJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyMedJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyMedJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyHighJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJob(TestName, new BurstAccuracyHighJob(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),

                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyStdJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyStdJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyLowJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyLowJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyMedJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyMedJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyHighJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float>.RunIJobParallelFor(TestName, new BurstAccuracyHighJobParallelFor(),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    inputDataContainer.GetData<float>(DataConfig.DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true, 64)),

                #endregion
            };
        }
    }
}