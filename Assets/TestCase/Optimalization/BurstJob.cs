using TestRunner.Workers;
using Unity.Burst;
using Unity.Collections;

namespace TestCase.Optimalization
{
    [BurstCompile]
    public struct BurstJob : IJobExt<int, int>
    {
        private NativeArray<int> _data1;
        private NativeArray<int> _data2;

        public int DataSize { get; set; }

        public NativeArray<int> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<int> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data2[i] = _data1[i];
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