using TestRunner.Wrappers.Base.Config;

namespace TestRunner.DataContainer.Array
{
    internal class ArrayContainer<TConfig, T1, T2, T3, T4> : ArrayContainer<TConfig, T1, T2, T3>,
        IArrayContainer<TConfig, T1, T2, T3, T4>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
    {
        private readonly T4[] _itemArray4;

        public T4[] Item4 { get; private set; }

        public ArrayContainer(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3, T4[] itemArray4) : base(itemArray1,
            itemArray2, itemArray3)
        {
            _itemArray4 = itemArray4;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            Item4 = default(T4[]);
        }

        protected override void PrepareData(TConfig config)
        {
            base.PrepareData(config);
            Item4 = _itemArray4.Clone() as T4[];
        }
    }
}