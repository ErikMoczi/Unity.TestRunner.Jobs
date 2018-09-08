using TestWrapper.Workers;

namespace TestCase.DataStructure
{
    public struct ArrayPlain : IPlainExt<float[], float[]>
    {
        private float[] _data1;
        private float[] _data2;

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

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data2[i] = _data1[i];
            }
        }
    }
}