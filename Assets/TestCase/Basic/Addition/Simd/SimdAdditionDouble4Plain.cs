using TestRunner.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Addition.Simd
{
    public struct SimdAdditionDouble4Plain : IPlainExt<double4[], double4[], double4[]>
    {
        private double4[] _data1;
        private double4[] _data2;
        private double4[] _data3;

        public int DataSize { get; set; }

        public double4[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public double4[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public double4[] Data3
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
    }
}