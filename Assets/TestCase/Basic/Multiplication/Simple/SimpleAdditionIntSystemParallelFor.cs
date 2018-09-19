using TestWrapper.Workers;

namespace TestCase.Basic.Multiplication.Simple
{
    public struct SimpleMultiplicationIntSystemParallelFor : ISystemParallelForExt<int[], int[], int[]>
    {
        private int[] _data1;
        private int[] _data2;
        private int[] _data3;

        public int DataSize { get; set; }

        public int[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public int[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public int[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] * _data2[i];
        }

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}