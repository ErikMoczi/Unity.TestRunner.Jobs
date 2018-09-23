using System;

namespace TestRunnerPerformance
{
    [Serializable]
    internal class Wrapper<T>
    {
        public T[] data;
    }
}