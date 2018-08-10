using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WorkSpace.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAllDerivedTypes(this Type type)
        {
            return Assembly.GetAssembly(type).GetAllDerivedTypes(type);
        }

        public static List<string> GetAllPublicConstantNames(this Type type)
        {
            return type
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                .Select(x => x.Name)
                .ToList();
        }
    }
}