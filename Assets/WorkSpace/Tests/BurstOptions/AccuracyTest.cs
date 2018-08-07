using TestCase.BurstOptions;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.BurstOptions
{
    public sealed class AccuracyTest : SampleGenerator
    {
        private const string TestName = nameof(AccuracyTest);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(float), DataConfig.DataFloat1),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
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
            };
        }
    }
}