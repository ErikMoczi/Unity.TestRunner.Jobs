using System;

namespace TestRunner.Container.WorkRunner
{
    internal interface IJobExtensionsWrapper
    {
        Type ExtensionType { get; }
        string MethodNameUnBatched { get; }
        string MethodNameBatched { get; }
    }
}