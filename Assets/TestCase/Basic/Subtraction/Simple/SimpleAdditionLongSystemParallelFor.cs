using TestWrapper.Workers;

namespace TestCase.Basic.Subtraction.Simple
{
    public struct SimpleSubtractionLongSystemParallelFor : ISystemParallelForExt<long[], long[], long[]>
    {
        private long[] _data1;
        private long[] _data2;
        private long[] _data3;

        public int DataSize { get; set; }

        public long[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public long[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public long[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] - _data2[i];
        }
    }
}