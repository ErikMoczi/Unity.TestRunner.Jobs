using System;
using System.Collections.Generic;
using System.Linq;
using TestWrapper.Utils;
using WorkSpace.Extensions;

namespace WorkSpace.Tests.Base
{
    public sealed class SampleGeneratorData : ISampleGeneratorData
    {
        public const string TargetPropertyName = "Generators";
        public const char KeySeparator = '.';
        public const char ValueSeparator = '/';
        private const string SufixBasicTests = "TypeTest";

        private readonly string _prefixWorkspace;

        public string PrefixWorkspace => _prefixWorkspace;

        private readonly Type _lookingClasses = typeof(ISampleGenerator);

        private readonly Dictionary<string, string> _sampleGenerators;
        private readonly Dictionary<string, string> _sampleGeneratorCategories;
        private readonly Dictionary<string, string> _activeGenerators = new Dictionary<string, string>();

        public SampleGeneratorData()
        {
            var data = _lookingClasses.GetAllDerivedTypes().Select(type => type.FullName).ToArray();
            _prefixWorkspace =
                data.Length == 1 ? Utils.RemoveLastItem(data[0], KeySeparator) : Utils.CommonPrefix(data);
            _sampleGenerators = data.ToDictionary(item => item, CreateValue);
            _sampleGeneratorCategories = GenerateCategories();
        }

        public string CreateKey(string value)
        {
            return _prefixWorkspace + value.Replace(ValueSeparator, KeySeparator);
        }

        public string CreateValue(string value)
        {
            return value.Replace(_prefixWorkspace, string.Empty).Replace(KeySeparator, ValueSeparator);
        }

        public string Get(string item)
        {
            return _activeGenerators[item];
        }

        public IEnumerable<KeyValuePair<string, string>> GetUnused()
        {
            return _sampleGenerators.Except(_activeGenerators);
        }

        public IEnumerable<KeyValuePair<string, string>> GetCategories()
        {
            return _sampleGeneratorCategories;
        }

        public IEnumerable<KeyValuePair<string, string[]>> GetCategoriesExtra()
        {
            var inputDataTypeName = typeof(InputDataTypeName).GetAllPublicConstantNames();
            foreach (var value in inputDataTypeName)
            {
                var generators = _sampleGenerators.Keys.Where(item => item.Contains("." + value + SufixBasicTests))
                    .ToArray();
                yield return new KeyValuePair<string, string[]>(value, generators);
            }
        }

        public IEnumerable<string> GetByCategory(string category)
        {
            return _sampleGenerators.Keys.Where(key => key.StartsWith(category)).Except(_activeGenerators.Keys);
        }

        public bool Add(string item)
        {
            if (_sampleGenerators.TryGetValue(item, out var value))
            {
                _activeGenerators.Add(item, value);
                return true;
            }

            return false;
        }

        public void Remove(string item)
        {
            _activeGenerators.Remove(item);
        }

        public void Clear()
        {
            _activeGenerators.Clear();
        }

        private Dictionary<string, string> GenerateCategories()
        {
            return _sampleGenerators.Keys.GroupBy(item => Utils.RemoveLastItem(item, KeySeparator))
                .Select(item => item.Key).ToDictionary(item => item, CreateValue);
        }
    }
}