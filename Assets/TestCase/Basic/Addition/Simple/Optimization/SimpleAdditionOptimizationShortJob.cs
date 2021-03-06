﻿using TestWrapper.Workers;
using Unity.Burst;
using Unity.Collections;

namespace TestCase.Basic.Addition.Simple.Optimization
{
    [BurstCompile]
    public struct SimpleAdditionOptimizationShortJob : IJobExt<NativeArray<short>, NativeArray<short>, NativeArray<short>>
    {
        [ReadOnly] private NativeArray<short> _data1;
        [ReadOnly] private NativeArray<short> _data2;
        [WriteOnly] private NativeArray<short> _data3;

        public int DataSize { get; set; }

        public NativeArray<short> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<short> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<short> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = (short) (_data1[i] + _data2[i]);
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