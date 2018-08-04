﻿using TestRunner.Workers;
using Unity.Burst;
using Unity.Collections;

namespace TestCase.Basic.Subtraction.Simple.Optimalization
{
    [BurstCompile]
    public struct SimpleSubtractionOptimalizationFloatJob : IJobExt<float, float, float>
    {
        [ReadOnly] private NativeArray<float> _data1;
        [ReadOnly] private NativeArray<float> _data2;
        [WriteOnly] private NativeArray<float> _data3;

        public int DataSize { get; set; }

        public NativeArray<float> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<float> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<float> Data3
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

        public void Dispose()
        {
        }

        public void Init()
        {
        }
    }
}