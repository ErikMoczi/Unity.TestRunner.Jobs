using System;

namespace TestWrapper.Container.WorkRunner
{
    internal interface IJobExtensionsWrapper
    {
        Type ExtensionType { get; }
        string MethodNameUnBatched { get; }
        string MethodNameBatched { get; }
    }
}