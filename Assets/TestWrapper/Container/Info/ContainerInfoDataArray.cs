using System.Text;

namespace TestWrapper.Container.Info
{
    internal class ContainerInfoDataArray : IContainerInfoDataArray
    {
        private readonly IContainerInfoData[] _infoData;

        public IContainerInfoData this[int index] => _infoData[index];
        public int Length => _infoData.Length;

        public ContainerInfoDataArray(IContainerInfoData[] infoData)
        {
            _infoData = infoData;
        }

        public override string ToString()
        {
            var bbb = new StringBuilder();
            for (int i = 0; i < _infoData.Length; i++)
            {
                bbb.Append(_infoData[i]);
                if (i != _infoData.Length - 1)
                {
                    bbb.Append(", ");
                }
            }

            return $"{{{bbb}}}";
        }
    }
}