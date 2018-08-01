using TestCase.Basic.Addition;
using TestCase.Basic.Division;
using TestCase.Basic.Multiplication;
using TestCase.Basic.Subtraction;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace WorkSpace
{
    public class BasicTest : SampleGenerator
    {
        private const string TestName = nameof(BasicTest);
        private const string DataInt1 = "dataInt1";
        private const string DataFloat1 = "dataFloat1";

        protected override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int), DataInt1),
                new SampleConfig(typeof(float), DataFloat1),
            };
        }

        protected override IWorkWrapper[] InitWorkWrappers()
        {
            return new[]
            {
                #region Addition

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunINonJob(TestName, new SimpleAdditionIntNonJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1)),

                WorkerTests<float, float, float>.RunIJob(TestName, new SimpleAdditionFloatJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunIJobParallelFor(TestName, new SimpleAdditionFloatJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunINonJob(TestName, new SimpleAdditionFloatNonJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1)),

                #endregion

                #region Division

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleDivisionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleDivisionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunINonJob(TestName, new SimpleDivisionIntNonJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1)),

                WorkerTests<float, float, float>.RunIJob(TestName, new SimpleDivisionFloatJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunIJobParallelFor(TestName, new SimpleDivisionFloatJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunINonJob(TestName, new SimpleDivisionFloatNonJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1)),

                #endregion

                #region Multiplication

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleMultiplicationIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleMultiplicationIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunINonJob(TestName, new SimpleMultiplicationIntNonJob(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1)),

                WorkerTests<float, float, float>.RunIJob(TestName, new SimpleMultiplicationFloatJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationFloatJobParallelFor(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunINonJob(TestName, new SimpleMultiplicationFloatNonJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1)),

                #endregion

                #region Subtraction

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleSubtractionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName, new SimpleSubtractionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunINonJob(TestName, new SimpleSubtractionIntNonJob(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1)),

                WorkerTests<float, float, float>.RunIJob(TestName, new SimpleSubtractionFloatJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionFloatJobParallelFor(), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunINonJob(TestName, new SimpleSubtractionFloatNonJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1)),

                #endregion
            };
        }
    }
}