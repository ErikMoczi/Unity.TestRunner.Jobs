using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;
using Unity.Collections;

namespace TestWrapper.Config.Data
{
    public class DataConfigUnityCollection : DataConfig, IDataConfigUnityCollection
    {
        public Allocator Allocator { get; }

        public DataConfigUnityCollection(Allocator allocator)
        {
            Allocator = allocator;
        }

        protected override void AppendToString(Dictionary<string, string> fields)
        {
            fields.Add(nameof(Allocator), Allocator.ToString());
        }
    }
}