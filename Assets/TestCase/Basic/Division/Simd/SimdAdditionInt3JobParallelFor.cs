using TestWrapper.Workers;
using Unity.Collections;
using Unity.Mathematics;

namespace TestCase.Basic.Division.Simd
{
    public struct SimdDivisionInt3JobParallelFor : IJobParallelForExt<NativeArray<int3>, NativeArray<int3>, NativeArray<int3>>
    {
        private NativeArray<int3> _data1;
        private NativeArray<int3> _data2;
        private NativeArray<int3> _data3;

        public int DataSize { get; set; }

        public NativeArray<int3> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<int3> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<int3> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] / _data2[i];
        }

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}