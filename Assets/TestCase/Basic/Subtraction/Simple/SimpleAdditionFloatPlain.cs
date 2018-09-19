using TestWrapper.Workers;

namespace TestCase.Basic.Subtraction.Simple
{
    public struct SimpleSubtractionFloatPlain : IPlainExt<float[], float[], float[]>
    {
        private float[] _data1;
        private float[] _data2;
        private float[] _data3;

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

        public float[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] - _data2[i];
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