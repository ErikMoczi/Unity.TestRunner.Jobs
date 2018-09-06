using System;
using TestRunner.Facades.SetUp;

namespace TestRunner.Facades
{
    internal interface IWorkFacade : IDisposable, IWorkerWrapperInfo
    {
        void Init();
        void Run();
    }
}