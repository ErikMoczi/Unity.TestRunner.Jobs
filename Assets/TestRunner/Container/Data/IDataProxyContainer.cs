using System;
using TestRunner.Container.SetUp;

namespace TestRunner.Container.Data
{
    internal interface IDataProxyContainer<T> : IDisposable, IContainerInfo
    {
        T Value { get; }
        void Init();
    }
}