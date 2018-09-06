using System;

namespace TestRunner.Container
{
    internal interface IRefreshContainer : IBaseContainer, IDisposable
    {
        void Init();
    }
}