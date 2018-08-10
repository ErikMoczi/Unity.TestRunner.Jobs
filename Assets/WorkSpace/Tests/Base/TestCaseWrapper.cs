using System;

namespace WorkSpace.Tests.Base
{
    [Serializable]
    public sealed class TestCaseWrapper
    {
        public string[] Generators;
        public int TotalGenerators => Generators.Length;
    }
}