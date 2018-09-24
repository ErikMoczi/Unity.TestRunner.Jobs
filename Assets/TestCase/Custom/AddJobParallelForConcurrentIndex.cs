using TestWrapper.DataType;
using TestWrapper.Workers;
using Unity.Burst;

namespace TestCase.Custom
{
    [BurstCompile]
    public struct AddJobParallelForConcurrentIndex : IJobParallelForExt<NativeConcurrentIntArray.Concurrent>
    {
        private NativeConcurrentIntArray.Concurrent _data1;

        public int DataSize { get; set; }

        public NativeConcurrentIntArray.Concurrent Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public void Execute(int i)
        {
            _data1.Add(i, 1);
        }

        public void CustomSetUp()
        {
        }

        public void CustomCleanUp()
        {
        }
    }
}