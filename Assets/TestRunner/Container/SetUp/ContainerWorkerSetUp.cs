namespace TestRunner.Container.SetUp
{
    internal class ContainerWorkerSetUp : ContainerSetUp, IContainerWorkerSetUp
    {
        private readonly string _jobType;

        public string JobType => _jobType;

        public ContainerWorkerSetUp(string name, string ns, string config, string jobType) : base(name, ns, config)
        {
            _jobType = jobType;
        }
    }
}