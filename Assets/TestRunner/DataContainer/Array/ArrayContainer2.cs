using TestRunner.Wrappers.Base.Config;

namespace TestRunner.DataContainer.Array
{
    internal class ArrayContainer<TConfig, T1, T2> : ArrayContainer<TConfig, T1>, IArrayContainer<TConfig, T1, T2>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
    {
        private readonly T2[] _itemArray2;

        public T2[] Item2 { get; private set; }

        public ArrayContainer(T1[] itemArray1, T2[] itemArray2) : base(itemArray1)
        {
            _itemArray2 = itemArray2;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            Item2 = default(T2[]);
        }

        protected override void PrepareData(TConfig config)
        {
            base.PrepareData(config);
            Item2 = _itemArray2.Clone() as T2[];
        }
    }
}