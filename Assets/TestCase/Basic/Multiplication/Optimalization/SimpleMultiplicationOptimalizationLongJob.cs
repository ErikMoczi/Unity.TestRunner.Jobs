using TestRunner.Workers;
using Unity.Burst;
using Unity.Collections;

namespace TestCase.Basic.Multiplication.Optimalization
{
    [BurstCompile]
    public struct SimpleMultiplicationOptimalizationLongJob : IJobExt<long, long, long>
    {
        [ReadOnly] private NativeArray<long> _data1;
        [ReadOnly] private NativeArray<long> _data2;
        [WriteOnly] private NativeArray<long> _data3;

        public int DataSize { get; set; }

        public NativeArray<long> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<long> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<long> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] * _data2[i];
            }
        }

        public void Dispose()
        {
        }

        public void Init()
        {
        }
    }
}