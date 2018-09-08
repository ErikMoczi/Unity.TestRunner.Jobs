using System.Collections.Generic;
using TestWrapper.Config.Data.Interfaces;

namespace TestWrapper.Config.Data
{
    public class DataConfigDefault : DataConfig, IDataConfigDefault
    {
        protected override void AppendToString(Dictionary<string, string> fields)
        {
        }
    }
}