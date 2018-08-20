using TestRunner.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Operators.Equivalence.Simd
{
    public struct SimdOperatorsEquivalenceBool2NonJob : INonJobExt<bool2, bool2, bool2>
    {
        private bool2[] _data1;
        private bool2[] _data2;
        private bool2[] _data3;

        public int DataSize { get; set; }

        public bool2[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public bool2[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public bool2[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] == _data2[i];
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