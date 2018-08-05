using TestRunner.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Multiplication.Simd
{
    public struct SimdMultiplicationInt4NonJob : INonJobExt<int4, int4, int4>
    {
        private int4[] _data1;
        private int4[] _data2;
        private int4[] _data3;

        public int DataSize { get; set; }

        public int4[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public int4[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public int4[] Data3
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