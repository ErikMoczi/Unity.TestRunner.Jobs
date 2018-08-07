using System;

namespace WorkSpace
{
    [Serializable]
    public sealed class TestCase
    {
        public string[] Generators;
        public int TotalGenerators => Generators.Length;
    }
}