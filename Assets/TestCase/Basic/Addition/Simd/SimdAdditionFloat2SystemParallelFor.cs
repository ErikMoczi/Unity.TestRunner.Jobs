using TestRunner.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Addition.Simd
{
    public struct SimdAdditionFloat2SystemParallelFor : ISystemParallelForExt<float2[], float2[], float2[]>
    {
        private float2[] _data1;
        private float2[] _data2;
        private float2[] _data3;

        public int DataSize { get; set; }

        public float2[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public float2[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public float2[] Data3
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