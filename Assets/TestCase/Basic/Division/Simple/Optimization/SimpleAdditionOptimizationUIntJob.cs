using TestWrapper.Workers;
using Unity.Burst;
using Unity.Collections;

namespace TestCase.Basic.Division.Simple.Optimization
{
    [BurstCompile]
    public struct SimpleDivisionOptimizationUIntJob : IJobExt<NativeArray<uint>, NativeArray<uint>, NativeArray<uint>>
    {
        [ReadOnly] private NativeArray<uint> _data1;
        [ReadOnly] private NativeArray<uint> _data2;
        [WriteOnly] private NativeArray<uint> _data3;

        public int DataSize { get; set; }

        public NativeArray<uint> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<uint> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<uint> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] / _data2[i];
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