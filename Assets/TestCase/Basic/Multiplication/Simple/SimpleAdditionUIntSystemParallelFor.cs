using TestWrapper.Workers;

namespace TestCase.Basic.Multiplication.Simple
{
    public struct SimpleMultiplicationUIntSystemParallelFor : ISystemParallelForExt<uint[], uint[], uint[]>
    {
        private uint[] _data1;
        private uint[] _data2;
        private uint[] _data3;

        public int DataSize { get; set; }

        public uint[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public uint[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public uint[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] * _data2[i];
        }

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}