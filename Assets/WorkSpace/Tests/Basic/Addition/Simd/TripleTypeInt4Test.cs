using TestCase.Basic.Addition.Simd;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;
using WorkSpace.Tests.Base;

namespace WorkSpace.Tests.Basic.Addition.Simd
{
    public sealed class TripleTypeInt4Test : SampleGenerator
    {
        private const string TestName = nameof(TripleTypeInt4Test);

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int4), DataConfig.DataInt4),
            };
        }

        public override IWorkWrapper[] InitWorkWrappers(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                WorkerTests<int4, int4, int4>.RunIJob(TestName, new SimdAdditionInt4Job(),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int4, int4, int4>.RunIJobParallelFor(TestName,
                    new SimdAdditionInt4JobParallelFor(),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    inputDataContainer.GetData<int4>(DataConfig.DataInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),
            };
        }
    }
}