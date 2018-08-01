using TestRunner.Wrappers.Base.Config;

namespace TestRunner.DataContainer.Array
{
    internal class ArrayContainer<TConfig, T1, T2, T3> : ArrayContainer<TConfig, T1, T2>,
        IArrayContainer<TConfig, T1, T2, T3>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
    {
        private readonly T3[] _itemArray3;

        public T3[] Item3 { get; private set; }

        public ArrayContainer(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3) : base(itemArray1, itemArray2)
        {
            _itemArray3 = itemArray3;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            Item3 = default(T3[]);
        }

        protected override void PrepareData(TConfig config)
        {
            base.PrepareData(config);
            Item3 = _itemArray3.Clone() as T3[];
        }
    }
}