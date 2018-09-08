using System;
using TestWrapper.Facades.Info;

namespace TestWrapper.Utils.Exceptions
{
    internal class TestRunnerException : Exception
    {
        public TestRunnerException(string methodName, IWorkWrapperInfo info, Exception innerException) : base(
            $"Error of running {methodName} for {info.TestName} - {info.InfoWorker}", innerException)
        {
        }
    }
}