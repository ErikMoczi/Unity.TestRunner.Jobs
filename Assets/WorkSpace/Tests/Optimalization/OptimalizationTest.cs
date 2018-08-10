using TestCase.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Optimalization
{
    public sealed class OptimalizationTest : SampleGenerator
    {
        private const string TestName = nameof(OptimalizationTest);

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
                WorkerTests<int, int>.RunIJob(TestName, new FullOptimizedJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstReadJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new BurstWriteJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJob(TestName, new ReadWriteJob(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1), new WorkConfigIJob(Allocator.Persistent)),

                WorkerTests<int, int>.RunIJobParallelFor(TestName, new FullOptimizedJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstReadJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new BurstWriteJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int>.RunIJobParallelFor(TestName, new ReadWriteJobParallelFor(),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    inputDataContainer.GetData<int>(DataConfig.DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
            };
        }
    }
}