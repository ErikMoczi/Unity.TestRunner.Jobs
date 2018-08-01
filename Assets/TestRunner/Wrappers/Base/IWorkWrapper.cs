using System;

namespace TestRunner.Wrappers.Base
{
    public interface IWorkWrapper : IDisposable
    {
        void Run();
    }
}