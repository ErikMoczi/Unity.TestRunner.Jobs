using TestWrapper.Workers;
using Unity.Collections;

namespace TestCase.Optimization
{
    public struct ReadWriteSystemParallelFor : ISystemParallelForExt<float[], float[]>
    {
        [ReadOnly] private float[] _data1;
        [WriteOnly] private float[] _data2;

        public int DataSize { get; set; }

        public float[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public float[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public void Execute(int i)
        {
            _data2[i] = _data1[i];
        }

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}