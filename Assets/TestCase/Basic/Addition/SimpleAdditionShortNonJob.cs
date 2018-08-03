using TestRunner.Workers;

namespace TestCase.Basic.Addition
{
    public struct SimpleAdditionShortNonJob : INonJobExt<short, short, short>
    {
        private short[] _data1;
        private short[] _data2;
        private short[] _data3;

        public int DataSize { get; set; }

        public short[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public short[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public short[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = (short) (_data1[i] + _data2[i]);
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