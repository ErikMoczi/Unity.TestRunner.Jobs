using TestWrapper.Workers;

namespace TestCase.Custom
{
    public struct AddPlain : IPlainExt<int[]>
    {
        private int[] _data1;

        public int DataSize { get; set; }

        public int[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data1[0] = _data1[0] + 1;
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