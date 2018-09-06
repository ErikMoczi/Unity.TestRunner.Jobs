﻿using TestRunner.Workers;
using Unity.Collections;

namespace TestCase.Basic.Multiplication.Simple
{
    public struct SimpleMultiplicationFloatJob : IJobExt<NativeArray<float>, NativeArray<float>, NativeArray<float>>
    {
        private NativeArray<float> _data1;
        private NativeArray<float> _data2;
        private NativeArray<float> _data3;

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
                _data3[i] = _data1[i] * _data2[i];
            }
        }
    }
}