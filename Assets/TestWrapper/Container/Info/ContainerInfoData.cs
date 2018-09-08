namespace TestWrapper.Container.Info
{
    internal class ContainerInfoData : ContainerInfo, IContainerInfoData
    {
        private readonly string _name;
        private readonly string _ns;

        public string Name => _name;
        public string Namespace => _ns;

        public ContainerInfoData(string name, string ns, string config) : base(config)
        {
            _name = name;
            _ns = ns;
        }

        public override string ToString()
        {
            return $"{Name}{base.ToString()}";
        }
    }
}