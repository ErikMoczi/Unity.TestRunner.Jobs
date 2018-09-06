using System;

namespace TestRunner.Facades
{
    public interface ITestFacade : IDisposable
    {
        void Run();
    }
}