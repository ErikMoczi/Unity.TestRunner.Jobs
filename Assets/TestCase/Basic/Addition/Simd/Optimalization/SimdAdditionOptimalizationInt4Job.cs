﻿using TestRunner.Workers;
using Unity.Burst;
using Unity.Collections;
using Unity.Mathematics;

namespace TestCase.Basic.Addition.Simd.Optimalization
{
    [BurstCompile]
    public struct SimdAdditionOptimalizationInt4Job : IJobExt<int4, int4, int4>
    {
        [ReadOnly] private NativeArray<int4> _data1;
        [ReadOnly] private NativeArray<int4> _data2;
        [WriteOnly] private NativeArray<int4> _data3;

        public int DataSize { get; set; }

        public NativeArray<int4> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<int4> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<int4> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] + _data2[i];
            }
        }

        public void Dispose()
        {
        }

        public void Init()
        {
        }
    }
}