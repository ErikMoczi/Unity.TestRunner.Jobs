using TestRunner.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Operators.Or.Simd
{
    public struct SimdOperatorsOrBool3NonJob : INonJobExt<bool3, bool3, bool3>
    {
        private bool3[] _data1;
        private bool3[] _data2;
        private bool3[] _data3;

        public int DataSize { get; set; }

        public bool3[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public bool3[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public bool3[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] | _data2[i];
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