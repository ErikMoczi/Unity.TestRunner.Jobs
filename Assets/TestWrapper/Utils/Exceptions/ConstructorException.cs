using System;

namespace TestWrapper.Utils.Exceptions
{
    internal class ConstructorException : Exception
    {
        public ConstructorException(string testName, Type worker, Exception innerException) : base(
            $"Constructing error of {testName} - {worker}", innerException)
        {
        }
    }
}