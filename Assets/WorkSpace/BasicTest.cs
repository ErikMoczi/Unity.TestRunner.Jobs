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

                WorkerTests<int, int, int>.RunIJob(new SimpleAdditionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJobParallelFor(new SimpleAdditionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunINonJob(new SimpleAdditionIntNonJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1)),

                WorkerTests<float, float, float>.RunIJob(new SimpleAdditionFloatJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunIJobParallelFor(new SimpleAdditionFloatJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunINonJob(new SimpleAdditionFloatNonJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1)),

                #endregion

                #region Division

                WorkerTests<int, int, int>.RunIJob(new SimpleDivisionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJobParallelFor(new SimpleDivisionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunINonJob(new SimpleDivisionIntNonJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1)),

                WorkerTests<float, float, float>.RunIJob(new SimpleDivisionFloatJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunIJobParallelFor(new SimpleDivisionFloatJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunINonJob(new SimpleDivisionFloatNonJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1)),

                #endregion

                #region Multiplication

                WorkerTests<int, int, int>.RunIJob(new SimpleMultiplicationIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJobParallelFor(new SimpleMultiplicationIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunINonJob(new SimpleMultiplicationIntNonJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1)),

                WorkerTests<float, float, float>.RunIJob(new SimpleMultiplicationFloatJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunIJobParallelFor(new SimpleMultiplicationFloatJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunINonJob(new SimpleMultiplicationFloatNonJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1)),

                #endregion

                #region Subtraction

                WorkerTests<int, int, int>.RunIJob(new SimpleSubtractionIntJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunIJobParallelFor(new SimpleSubtractionIntJobParallelFor(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int, int, int>.RunINonJob(new SimpleSubtractionIntNonJob(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1)),

                WorkerTests<float, float, float>.RunIJob(new SimpleSubtractionFloatJob(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunIJobParallelFor(new SimpleSubtractionFloatJobParallelFor(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float, float, float>.RunINonJob(new SimpleSubtractionFloatNonJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1)),

                #endregion
            };
        }
    }
}