﻿using TestRunner.Workers;

namespace TestCase.Basic.Multiplication.Simple
{
    public struct SimpleMultiplicationByteSystemParallelFor : ISystemParallelForExt<byte[], byte[], byte[]>
    {
        private byte[] _data1;
        private byte[] _data2;
        private byte[] _data3;

        public int DataSize { get; set; }

        public byte[] Data1
        {
            get => _data1;
            set => _data1 = value;
        }

        public byte[] Data2
        {
            get => _data2;
            set => _data2 = value;
        }

        public byte[] Data3
        {
            get => _data3;
            set => _data3 = value;
        }

        public void Execute(int i)
        {
            _data3[i] = (byte) (_data1[i] * _data2[i]);
        }
    }
}