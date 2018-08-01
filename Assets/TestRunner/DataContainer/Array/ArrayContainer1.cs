using TestRunner.Wrappers.Base.Config;

namespace TestRunner.DataContainer.Array
{
    internal class ArrayContainer<TConfig, T1> : DataContainer<TConfig>, IArrayContainer<TConfig, T1>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
    {
        private readonly T1[] _itemArray1;

        public T1[] Item1 { get; private set; }

        public ArrayContainer(T1[] itemArray1)
        {
            _itemArray1 = itemArray1;
            MaxDataSize = itemArray1.Length;
        }

        protected override void CleanUpData()
        {
            Item1 = default(T1[]);
        }

        protected override void PrepareData(TConfig config)
        {
            Item1 = _itemArray1.Clone() as T1[];
        }
    }
}