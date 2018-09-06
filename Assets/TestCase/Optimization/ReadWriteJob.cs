using TestRunner.Workers;
using Unity.Collections;

namespace TestCase.Optimization
{
    public struct ReadWriteJob : IJobExt<NativeArray<float>, NativeArray<float>>
    {
        [ReadOnly] private NativeArray<float> _data1;
        [WriteOnly] private NativeArray<float> _data2;

        public int DataSize { get; set; }

        public NativeArray<float> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<float> Data2
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
    }
}