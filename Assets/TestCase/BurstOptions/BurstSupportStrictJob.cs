﻿using TestRunner.Workers;
using Unity.Burst;
using Unity.Collections;

namespace TestCase.BurstOptions
{
    [BurstCompile(Support = Support.Strict)]
    public struct BurstSupportStrictJob : IJobExt<NativeArray<float>, NativeArray<float>>
    {
        private NativeArray<float> _data1;
        private NativeArray<float> _data2;

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

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data2[i] = _data1[i];
            }
        }
    }
}