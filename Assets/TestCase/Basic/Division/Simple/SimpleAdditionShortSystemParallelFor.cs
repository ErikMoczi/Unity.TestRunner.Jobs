﻿using TestWrapper.Workers;

namespace TestCase.Basic.Division.Simple
{
    public struct SimpleDivisionShortSystemParallelFor : ISystemParallelForExt<short[], short[], short[]>
    {
        private short[] _data1;
        private short[] _data2;
        private short[] _data3;

        public int DataSize { get; set; }

        public short[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public short[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public short[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = (short) (_data1[i] / _data2[i]);
        }
    }
}