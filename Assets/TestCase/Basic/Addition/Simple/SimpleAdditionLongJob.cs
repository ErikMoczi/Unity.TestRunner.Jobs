using TestWrapper.Workers;
using Unity.Collections;

namespace TestCase.Basic.Addition.Simple
{
    public struct SimpleAdditionLongJob : IJobExt<NativeArray<long>, NativeArray<long>, NativeArray<long>>
    {
        private NativeArray<long> _data1;
        private NativeArray<long> _data2;
        private NativeArray<long> _data3;

        public int DataSize { get; set; }

        public NativeArray<long> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<long> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<long> Data3
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