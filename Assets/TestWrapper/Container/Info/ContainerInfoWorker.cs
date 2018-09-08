namespace TestWrapper.Container.Info
{
    internal class ContainerInfoWorker : ContainerInfoData, IContainerInfoWorker
    {
        private readonly string _jobType;
        public string JobType => _jobType;

        public ContainerInfoWorker(string name, string ns, string config, string jobType) : base(name, ns, config)
        {
            _jobType = jobType;
        }

        public override string ToString()
        {
            var config = string.IsNullOrEmpty(Config) ? string.Empty : $"({Config})";
            return $"{Name}<{_jobType}>{config}";
        }
    }
}