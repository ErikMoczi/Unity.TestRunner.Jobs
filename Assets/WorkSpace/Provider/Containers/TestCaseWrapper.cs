using System;

namespace WorkSpace.Provider.Containers
{
    [Serializable]
    public sealed class TestCaseWrapper
    {
        public string[] Generators;
        public int TotalGenerators => Generators.Length;
    }
}