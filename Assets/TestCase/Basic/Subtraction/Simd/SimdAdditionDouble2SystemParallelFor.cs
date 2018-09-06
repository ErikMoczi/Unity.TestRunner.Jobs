﻿using TestRunner.Workers;
using Unity.Mathematics;

namespace TestCase.Basic.Subtraction.Simd
{
    public struct SimdSubtractionDouble2SystemParallelFor : ISystemParallelForExt<double2[], double2[], double2[]>
    {
        private double2[] _data1;
        private double2[] _data2;
        private double2[] _data3;

        public int DataSize { get; set; }

        public double2[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public double2[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public double2[] Data3
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