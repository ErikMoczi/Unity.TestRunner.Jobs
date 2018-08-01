using TestRunner.Wrappers.Base.Config;

namespace TestRunner.DataContainer.Array
{
    internal class ArrayContainer<TConfig, T1, T2, T3, T4, T5> : ArrayContainer<TConfig, T1, T2, T3, T4>,
        IArrayContainer<TConfig, T1, T2, T3, T4, T5>
        where TConfig : IWorkConfigINonJob
        where T1 : struct
        where T2 : struct
        where T3 : struct
        where T4 : struct
        where T5 : struct
    {
        private readonly T5[] _itemArray5;

        public T5[] Item5 { get; private set; }

        public ArrayContainer(T1[] itemArray1, T2[] itemArray2, T3[] itemArray3, T4[] itemArray4, T5[] itemArray5) :
            base(itemArray1, itemArray2, itemArray3, itemArray4)
        {
            _itemArray5 = itemArray5;
        }

        protected override void CleanUpData()
        {
            base.CleanUpData();
            Item5 = default(T5[]);
        }

        protected override void PrepareData(TConfig config)
        {
            base.PrepareData(config);
            Item5 = _itemArray5.Clone() as T5[];
        }
    }
}