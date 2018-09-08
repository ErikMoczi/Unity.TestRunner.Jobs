using TestWrapper.Workers;
using Unity.Collections;

namespace TestCase.Basic.Multiplication.Simple
{
    public struct SimpleMultiplicationDoubleJobParallelFor : IJobParallelForExt<NativeArray<double>, NativeArray<double>, NativeArray<double>>
    {
        private NativeArray<double> _data1;
        private NativeArray<double> _data2;
        private NativeArray<double> _data3;

        public int DataSize { get; set; }

        public NativeArray<double> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<double> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<double> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] * _data2[i];
        }
    }
}