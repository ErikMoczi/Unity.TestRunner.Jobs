﻿using TestRunner.Workers;
using Unity.Burst;
using Unity.Collections;

namespace TestCase.Optimalization
{
    [BurstCompile]
    public struct FullOptimizedJob : IJobExt<int, int>
    {
        [ReadOnly] private NativeArray<int> _data1;
        [WriteOnly] private NativeArray<int> _data2;

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

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data2[i] = _data1[i];
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