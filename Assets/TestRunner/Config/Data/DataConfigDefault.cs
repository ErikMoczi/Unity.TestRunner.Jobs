using System.Collections.Generic;
using TestRunner.Config.Data.Interfaces;

namespace TestRunner.Config.Data
{
    public class DataConfigDefault : DataConfig, IDataConfigDefault
    {
        protected override void AppendToString(Dictionary<string, string> fields)
        {
        }
    }
}