﻿using System.Collections.Generic;

namespace WorkSpace.Tests.Base
{
    public interface ISampleGeneratorData
    {
        string PrefixWorkspace { get; }
        string CreateKey(string value);
        string CreateValue(string value);
        string Get(string item);
        IEnumerable<KeyValuePair<string, string>> GetUnused();
        IEnumerable<KeyValuePair<string, string>> GetCategories();
        IEnumerable<string> GetByCategory(string category);
        bool Add(string item);
        void Remove(string item);
        void Clear();
    }
}