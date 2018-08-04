using TestCase.Basic.Addition.Optimalization;
using TestCase.Basic.Division.Optimalization;
using TestCase.Basic.Multiplication.Optimalization;
using TestCase.Basic.Subtraction.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;

namespace WorkSpace
{
    public class BasicOptimalizationTest : SampleGenerator
    {
        private const string TestName = nameof(BasicOptimalizationTest);
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

                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleAdditionOptimalizationByteJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName,
                    new SimpleAdditionOptimalizationByteJobParallelFor(), GetData<byte>(DataByte1),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<double, double, double>.RunIJob(TestName, new SimpleAdditionOptimalizationDoubleJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<double, double, double>.RunIJobParallelFor(TestName,
                    new SimpleAdditionOptimalizationDoubleJobParallelFor(), GetData<double>(DataDouble1),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleAdditionOptimalizationIntJob(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName,
                    new SimpleAdditionOptimalizationIntJobParallelFor(), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float, float, float>.RunIJob(TestName, new SimpleAdditionOptimalizationFloatJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float, float>.RunIJobParallelFor(TestName,
                    new SimpleAdditionOptimalizationFloatJobParallelFor(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleAdditionOptimalizationLongJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName,
                    new SimpleAdditionOptimalizationLongJobParallelFor(), GetData<long>(DataLong1),
                    GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<short, short, short>.RunIJob(TestName, new SimpleAdditionOptimalizationShortJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<short, short, short>.RunIJobParallelFor(TestName,
                    new SimpleAdditionOptimalizationShortJobParallelFor(), GetData<short>(DataShort1),
                    GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint, uint, uint>.RunIJob(TestName, new SimpleAdditionOptimalizationUIntJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint, uint, uint>.RunIJobParallelFor(TestName,
                    new SimpleAdditionOptimalizationUIntJobParallelFor(), GetData<uint>(DataUInt1),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                #endregion

                #region Division

                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleDivisionOptimalizationByteJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName,
                    new SimpleDivisionOptimalizationByteJobParallelFor(), GetData<byte>(DataByte1),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<double, double, double>.RunIJob(TestName, new SimpleDivisionOptimalizationDoubleJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<double, double, double>.RunIJobParallelFor(TestName,
                    new SimpleDivisionOptimalizationDoubleJobParallelFor(), GetData<double>(DataDouble1),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleDivisionOptimalizationIntJob(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName,
                    new SimpleDivisionOptimalizationIntJobParallelFor(), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float, float, float>.RunIJob(TestName, new SimpleDivisionOptimalizationFloatJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float, float>.RunIJobParallelFor(TestName,
                    new SimpleDivisionOptimalizationFloatJobParallelFor(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleDivisionOptimalizationLongJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName,
                    new SimpleDivisionOptimalizationLongJobParallelFor(), GetData<long>(DataLong1),
                    GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<short, short, short>.RunIJob(TestName, new SimpleDivisionOptimalizationShortJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<short, short, short>.RunIJobParallelFor(TestName,
                    new SimpleDivisionOptimalizationShortJobParallelFor(), GetData<short>(DataShort1),
                    GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint, uint, uint>.RunIJob(TestName, new SimpleDivisionOptimalizationUIntJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint, uint, uint>.RunIJobParallelFor(TestName,
                    new SimpleDivisionOptimalizationUIntJobParallelFor(), GetData<uint>(DataUInt1),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                #endregion

                #region Multiplication

                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleMultiplicationOptimalizationByteJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationOptimalizationByteJobParallelFor(), GetData<byte>(DataByte1),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<double, double, double>.RunIJob(TestName, new SimpleMultiplicationOptimalizationDoubleJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<double, double, double>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationOptimalizationDoubleJobParallelFor(), GetData<double>(DataDouble1),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleMultiplicationOptimalizationIntJob(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationOptimalizationIntJobParallelFor(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float, float, float>.RunIJob(TestName, new SimpleMultiplicationOptimalizationFloatJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float, float>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationOptimalizationFloatJobParallelFor(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleMultiplicationOptimalizationLongJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationOptimalizationLongJobParallelFor(), GetData<long>(DataLong1),
                    GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<short, short, short>.RunIJob(TestName, new SimpleMultiplicationOptimalizationShortJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<short, short, short>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationOptimalizationShortJobParallelFor(), GetData<short>(DataShort1),
                    GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint, uint, uint>.RunIJob(TestName, new SimpleMultiplicationOptimalizationUIntJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint, uint, uint>.RunIJobParallelFor(TestName,
                    new SimpleMultiplicationOptimalizationUIntJobParallelFor(), GetData<uint>(DataUInt1),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                #endregion

                #region Subtraction

                WorkerTests<byte, byte, byte>.RunIJob(TestName, new SimpleSubtractionOptimalizationByteJob(),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<byte, byte, byte>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionOptimalizationByteJobParallelFor(), GetData<byte>(DataByte1),
                    GetData<byte>(DataByte1), GetData<byte>(DataByte1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<double, double, double>.RunIJob(TestName, new SimpleSubtractionOptimalizationDoubleJob(),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<double, double, double>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionOptimalizationDoubleJobParallelFor(), GetData<double>(DataDouble1),
                    GetData<double>(DataDouble1), GetData<double>(DataDouble1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int, int, int>.RunIJob(TestName, new SimpleSubtractionOptimalizationIntJob(),
                    GetData<int>(DataInt1), GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int, int, int>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionOptimalizationIntJobParallelFor(), GetData<int>(DataInt1),
                    GetData<int>(DataInt1), GetData<int>(DataInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float, float, float>.RunIJob(TestName, new SimpleSubtractionOptimalizationFloatJob(),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float, float, float>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionOptimalizationFloatJobParallelFor(), GetData<float>(DataFloat1),
                    GetData<float>(DataFloat1), GetData<float>(DataFloat1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<long, long, long>.RunIJob(TestName, new SimpleSubtractionOptimalizationLongJob(),
                    GetData<long>(DataLong1), GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<long, long, long>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionOptimalizationLongJobParallelFor(), GetData<long>(DataLong1),
                    GetData<long>(DataLong1), GetData<long>(DataLong1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<short, short, short>.RunIJob(TestName, new SimpleSubtractionOptimalizationShortJob(),
                    GetData<short>(DataShort1), GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<short, short, short>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionOptimalizationShortJobParallelFor(), GetData<short>(DataShort1),
                    GetData<short>(DataShort1), GetData<short>(DataShort1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint, uint, uint>.RunIJob(TestName, new SimpleSubtractionOptimalizationUIntJob(),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint, uint, uint>.RunIJobParallelFor(TestName,
                    new SimpleSubtractionOptimalizationUIntJobParallelFor(), GetData<uint>(DataUInt1),
                    GetData<uint>(DataUInt1), GetData<uint>(DataUInt1),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                #endregion
            };
        }
    }
}