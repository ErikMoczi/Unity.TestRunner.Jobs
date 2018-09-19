using TestWrapper.Workers;
using Unity.Collections;

namespace TestCase.Basic.Subtraction.Simple
{
    public struct SimpleSubtractionIntJobParallelFor : IJobParallelForExt<NativeArray<int>, NativeArray<int>, NativeArray<int>>
    {
        private NativeArray<int> _data1;
        private NativeArray<int> _data2;
        private NativeArray<int> _data3;

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

        public NativeArray<int> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] - _data2[i];
        }

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}