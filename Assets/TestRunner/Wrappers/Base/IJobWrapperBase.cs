using System;
using Unity.Collections;

namespace TestRunner.Wrappers.Base
{
    public interface IJobWrapperBase : IDisposable
    {
        void Run(Allocator allocator, bool scheduled = false);
    }
}