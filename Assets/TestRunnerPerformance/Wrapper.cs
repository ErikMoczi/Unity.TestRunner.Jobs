using System;

namespace TestRunnerPerformance
{
    [Serializable]
    public class Wrapper<T>
    {
        public T[] data;
    }
}