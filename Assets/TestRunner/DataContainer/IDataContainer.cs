using System;
using TestRunner.Wrappers.Base.Config;

namespace TestRunner.DataContainer
{
    internal interface IDataContainer<TConfig> : IDisposable
        where TConfig : IWorkConfig
    {
        int DataSize { get; }
        void Init(TConfig config);
    }
}