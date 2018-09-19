using TestWrapper.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Division.Simd
{
    public struct SimdDivisionUInt3Plain : IPlainExt<uint3[], uint3[], uint3[]>
    {
        private uint3[] _data1;
        private uint3[] _data2;
        private uint3[] _data3;

        public int DataSize { get; set; }

        public uint3[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public uint3[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public uint3[] Data3
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

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}