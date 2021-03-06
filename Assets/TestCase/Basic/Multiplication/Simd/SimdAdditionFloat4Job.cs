﻿using TestWrapper.Workers;
using Unity.Collections;
using Unity.Mathematics;

namespace TestCase.Basic.Multiplication.Simd
{
    public struct SimdMultiplicationFloat4Job : IJobExt<NativeArray<float4>, NativeArray<float4>, NativeArray<float4>>
    {
        private NativeArray<float4> _data1;
        private NativeArray<float4> _data2;
        private NativeArray<float4> _data3;

        public int DataSize { get; set; }

        public NativeArray<float4> Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public NativeArray<float4> Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public NativeArray<float4> Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute()
        {
            for (int i = 0; i < DataSize; i++)
            {
                _data3[i] = _data1[i] * _data2[i];
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