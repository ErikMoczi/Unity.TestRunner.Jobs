namespace TestRunner.Container.SetUp
{
    internal class ContainerSetUp : IContainerSetUp
    {
        private readonly string _name;
        private readonly string _config;
        private readonly string _ns;

        public string Name => _name;
        public string Config => _config;
        public string Namespace => _ns;

        public ContainerSetUp(string name, string ns, string config)
        {
            _name = name;
            _config = config;
            _ns = ns;
        }
    }
}