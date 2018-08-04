using TestCase.Basic.Addition.Simple;
using TestCase.Basic.Division.Simple;
using TestCase.Basic.Multiplication.Simple;
using TestCase.Basic.Subtraction.Simple;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace WorkSpace
{
    public class BasicSimpleTest : SampleGenerator
    {
        private const string TestName = nameof(BasicSimpleTest);
        private const string DataByte1 = "DataByte1";
        private const string DataDouble1 = "DataDouble1";
        private const string DataInt1 = "DataInt1";
        private const string DataFloat1 = "DataFloat1";
        private const string DataLong1 = "DataLong1";
        private const string DataShort1 = "DataShort1";
        private const string DataUInt1 = "DataUInt1";

        protected override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(byte), DataByte1),
                new SampleConfig(typeof(double), DataDouble1),
                new SampleConfig(typeof(int), DataInt1),
                new SampleConfig(typeof(float), DataFloat1),
                new SampleConfig(typeof(long), DataLong1),
                new SampleConfig(typeof(short), DataShort1),
                new SampleConfig(typeof(uint), DataUInt1),
            };
        }

        protected override IWorkWrapper[] InitWorkWrappers()
        {
            return new[]
            {
                #region Addition

                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleAdditionByteJob(), GetData<byte>(DataByte1),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName, new SimpleAdditionByteJobParallelFor(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<byte, byte, byte>.RunINonJob(TestName, new SimpleAdditionByteNonJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1)),

                WorkerTests<double, double, double>.RunIJob(TestName, new SimpleAdditionDoubleJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<double, double, double>.RunIJobParallelFor(TestName,
                    new SimpleAdditionDoubleJobParallelFor(), GetData<double>(DataDouble1),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<double, double, double>.RunINonJob(TestName, new SimpleAdditionDoubleNonJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1)),

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

                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleAdditionLongJob(), GetData<long>(DataLong1),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName, new SimpleAdditionLongJobParallelFor(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<long, long, long>.RunINonJob(TestName, new SimpleAdditionLongNonJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1)),

                WorkerTests<short, short, short>.RunIJob(TestName, new SimpleAdditionShortJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<short, short, short>.RunIJobParallelFor(TestName, new SimpleAdditionShortJobParallelFor(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<short, short, short>.RunINonJob(TestName, new SimpleAdditionShortNonJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1)),

                WorkerTests<uint, uint, uint>.RunIJob(TestName, new SimpleAdditionUIntJob(), GetData<uint>(DataUInt1),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint, uint, uint>.RunIJobParallelFor(TestName, new SimpleAdditionUIntJobParallelFor(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint, uint, uint>.RunINonJob(TestName, new SimpleAdditionUIntNonJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1)),

                #endregion

                #region Division

                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleDivisionByteJob(), GetData<byte>(DataByte1),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName, new SimpleDivisionByteJobParallelFor(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<byte, byte, byte>.RunINonJob(TestName, new SimpleDivisionByteNonJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1)),

                WorkerTests<double, double, double>.RunIJob(TestName, new SimpleDivisionDoubleJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<double, double, double>.RunIJobParallelFor(TestName,
                    new SimpleDivisionDoubleJobParallelFor(), GetData<double>(DataDouble1),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<double, double, double>.RunINonJob(TestName, new SimpleDivisionDoubleNonJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1)),

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

                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleDivisionLongJob(), GetData<long>(DataLong1),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName, new SimpleDivisionLongJobParallelFor(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<long, long, long>.RunINonJob(TestName, new SimpleDivisionLongNonJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1)),

                WorkerTests<short, short, short>.RunIJob(TestName, new SimpleDivisionShortJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<short, short, short>.RunIJobParallelFor(TestName, new SimpleDivisionShortJobParallelFor(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<short, short, short>.RunINonJob(TestName, new SimpleDivisionShortNonJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1)),

                WorkerTests<uint, uint, uint>.RunIJob(TestName, new SimpleDivisionUIntJob(), GetData<uint>(DataUInt1),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint, uint, uint>.RunIJobParallelFor(TestName, new SimpleDivisionUIntJobParallelFor(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint, uint, uint>.RunINonJob(TestName, new SimpleDivisionUIntNonJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1)),

                #endregion

                #region Multiplication

                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleMultiplicationByteJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName, new SimpleMultiplicationByteJobParallelFor(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<byte, byte, byte>.RunINonJob(TestName, new SimpleMultiplicationByteNonJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1)),

                WorkerTests<double, double, double>.RunIJob(TestName, new SimpleMultiplicationDoubleJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<double, double, double>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationDoubleJobParallelFor(), GetData<double>(DataDouble1),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<double, double, double>.RunINonJob(TestName, new SimpleMultiplicationDoubleNonJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1)),

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

                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleMultiplicationLongJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName, new SimpleMultiplicationLongJobParallelFor(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<long, long, long>.RunINonJob(TestName, new SimpleMultiplicationLongNonJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1)),

                WorkerTests<short, short, short>.RunIJob(TestName, new SimpleMultiplicationShortJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<short, short, short>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationShortJobParallelFor(), GetData<short>(DataShort1),
                    GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<short, short, short>.RunINonJob(TestName, new SimpleMultiplicationShortNonJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1)),

                WorkerTests<uint, uint, uint>.RunIJob(TestName, new SimpleMultiplicationUIntJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint, uint, uint>.RunIJobParallelFor(TestName, new SimpleMultiplicationUIntJobParallelFor(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint, uint, uint>.RunINonJob(TestName, new SimpleMultiplicationUIntNonJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1)),

                #endregion

                #region Subtraction

                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleSubtractionByteJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName, new SimpleSubtractionByteJobParallelFor(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<byte, byte, byte>.RunINonJob(TestName, new SimpleSubtractionByteNonJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1)),

                WorkerTests<double, double, double>.RunIJob(TestName, new SimpleSubtractionDoubleJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<double, double, double>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionDoubleJobParallelFor(), GetData<double>(DataDouble1),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<double, double, double>.RunINonJob(TestName, new SimpleSubtractionDoubleNonJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1)),

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

                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleSubtractionLongJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName, new SimpleSubtractionLongJobParallelFor(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<long, long, long>.RunINonJob(TestName, new SimpleSubtractionLongNonJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1)),

                WorkerTests<short, short, short>.RunIJob(TestName, new SimpleSubtractionShortJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<short, short, short>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionShortJobParallelFor(), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    GetData<short>(DataShort1), new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<short, short, short>.RunINonJob(TestName, new SimpleSubtractionShortNonJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1)),

                WorkerTests<uint, uint, uint>.RunIJob(TestName, new SimpleSubtractionUIntJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint, uint, uint>.RunIJobParallelFor(TestName, new SimpleSubtractionUIntJobParallelFor(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint, uint, uint>.RunINonJob(TestName, new SimpleSubtractionUIntNonJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1)),

                #endregion
            };
        }
    }
}