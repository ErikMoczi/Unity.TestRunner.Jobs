﻿using TestRunner.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Subtraction.Simd
{
    public struct SimdSubtractionDouble3SystemParallelFor : ISystemParallelForExt<double3[], double3[], double3[]>
    {
        private double3[] _data1;
        private double3[] _data2;
        private double3[] _data3;

        public int DataSize { get; set; }

        public double3[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public double3[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public double3[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = _data1[i] - _data2[i];
        }
    }
}