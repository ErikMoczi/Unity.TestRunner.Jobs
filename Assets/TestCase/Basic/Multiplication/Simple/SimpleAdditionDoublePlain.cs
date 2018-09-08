using TestWrapper.Workers;

namespace TestCase.Basic.Multiplication.Simple
{
    public struct SimpleMultiplicationDoublePlain : IPlainExt<double[], double[], double[]>
    {
        private double[] _data1;
        private double[] _data2;
        private double[] _data3;

        public int DataSize { get; set; }

        public double[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public double[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public double[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] * _data2[i];
            }
        }
    }
}