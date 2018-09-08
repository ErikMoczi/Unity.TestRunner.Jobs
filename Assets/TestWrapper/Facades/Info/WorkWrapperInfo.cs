using TestWrapper.Container.Info;

namespace TestWrapper.Facades.Info
{
    internal class WorkWrapperInfo : IWorkWrapperInfo
    {
        private readonly string _testName;
        private readonly IContainerInfoWorker _infoWorker;
        private readonly IContainerInfoDataArray _infoDataArray;

        public string TestName => _testName;
        public IContainerInfoWorker InfoWorker => _infoWorker;
        public IContainerInfoDataArray InfoDataArray => _infoDataArray;

        public WorkWrapperInfo(string testName, IContainerInfoWorker infoWorker,
            IContainerInfoDataArray infoDataArray)
        {
            _testName = testName;
            _infoWorker = infoWorker;
            _infoDataArray = infoDataArray;
        }

        public override string ToString()
        {
            return $"{_testName}: {_infoWorker} {_infoDataArray}";
        }
    }
}