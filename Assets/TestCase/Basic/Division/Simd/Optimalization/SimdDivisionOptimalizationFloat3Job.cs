using TestRunner.Workers;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace TestCase.Basic.Division.Simd.Optimalization
{
    [BurstCompile]
    public struct SimdDivisionOptimalizationFloat3Job : IJobExt<float3, float3, float3>
    {
        [ReadOnly] private NativeArray<float3> _data1;
        [ReadOnly] private NativeArray<float3> _data2;
        [WriteOnly] private NativeArray<float3> _data3;

        public int DataSize { get; set; }

        public NativeArray<float3> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<float3> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<float3> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] / _data2[i];
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