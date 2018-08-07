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
    public sealed class CompileSynchronouslyTest : SampleGenerator
    {
        private const string TestName = nameof(CompileSynchronouslyTest);

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
            };
        }
    }
}