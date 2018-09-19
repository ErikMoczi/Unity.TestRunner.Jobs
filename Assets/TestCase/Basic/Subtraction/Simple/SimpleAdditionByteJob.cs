using TestWrapper.Workers;
using Unity.Collections;

namespace TestCase.Basic.Subtraction.Simple
{
    public struct SimpleSubtractionByteJob : IJobExt<NativeArray<byte>, NativeArray<byte>, NativeArray<byte>>
    {
        private NativeArray<byte> _data1;
        private NativeArray<byte> _data2;
        private NativeArray<byte> _data3;

        public int DataSize { get; set; }

        public NativeArray<byte> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<byte> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<byte> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = (byte) (_data1[i] - _data2[i]);
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