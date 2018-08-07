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
    public sealed class SupportTest : SampleGenerator
    {
        private const string TestName = nameof(SupportTest);

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
            };
        }
    }
}