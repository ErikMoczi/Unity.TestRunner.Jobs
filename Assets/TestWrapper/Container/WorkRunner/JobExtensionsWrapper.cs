using System;

namespace TestWrapper.Container.WorkRunner
{
    internal sealed class JobExtensionsWrapper : IJobExtensionsWrapper
    {
        private readonly Type _extensionType;
        private readonly string _methodNameUnBatched;
        private readonly string _methodNameBatched;

        public Type ExtensionType => _extensionType;
        public string MethodNameUnBatched => _methodNameUnBatched;
        public string MethodNameBatched => _methodNameBatched;

        public JobExtensionsWrapper(Type extensionType, string methodNameBatched, string methodNameUnBatched)
        {
            _extensionType = extensionType;
            _methodNameBatched = methodNameBatched;
            _methodNameUnBatched = methodNameUnBatched;
        }
    }
}