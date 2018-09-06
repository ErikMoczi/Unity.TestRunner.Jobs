using TestRunner.Workers;
using Unity.Collections;

namespace TestCase.Basic.Subtraction.Simple
{
    public struct SimpleSubtractionShortJob : IJobExt<NativeArray<short>, NativeArray<short>, NativeArray<short>>
    {
        private NativeArray<short> _data1;
        private NativeArray<short> _data2;
        private NativeArray<short> _data3;

        public int DataSize { get; set; }

        public NativeArray<short> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<short> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<short> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = (short) (_data1[i] - _data2[i]);
            }
        }
    }
}