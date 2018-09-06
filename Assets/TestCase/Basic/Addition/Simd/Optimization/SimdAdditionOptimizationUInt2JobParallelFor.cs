using TestRunner.Workers;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace TestCase.Basic.Addition.Simd.Optimization
{
    [BurstCompile]
    public struct SimdAdditionOptimizationUInt2JobParallelFor : IJobParallelForExt<NativeArray<uint2>, NativeArray<uint2>, NativeArray<uint2>>
    {
        [ReadOnly] private NativeArray<uint2> _data1;
        [ReadOnly] private NativeArray<uint2> _data2;
        [WriteOnly] private NativeArray<uint2> _data3;

        public int DataSize { get; set; }

        public NativeArray<uint2> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<uint2> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<uint2> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] + _data2[i];
        }
    }
}