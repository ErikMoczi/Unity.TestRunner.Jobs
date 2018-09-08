namespace TestWrapper.Container.Info
{
    internal class ContainerInfo : IContainerInfo
    {
        private readonly string _config;
        public string Config => _config;

        public ContainerInfo(string config)
        {
            _config = config;
        }

        public override string ToString()
        {
            return string.IsNullOrEmpty(_config) ? string.Empty : $"({_config})";
        }
    }
}