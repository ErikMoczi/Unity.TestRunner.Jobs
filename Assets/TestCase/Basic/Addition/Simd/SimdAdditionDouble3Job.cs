using TestWrapper.Workers;
using Unity.Collections;
using Unity.Mathematics;

namespace TestCase.Basic.Addition.Simd
{
    public struct SimdAdditionDouble3Job : IJobExt<NativeArray<double3>, NativeArray<double3>, NativeArray<double3>>
    {
        private NativeArray<double3> _data1;
        private NativeArray<double3> _data2;
        private NativeArray<double3> _data3;

        public int DataSize { get; set; }

        public NativeArray<double3> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<double3> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<double3> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] + _data2[i];
            }
        }

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}