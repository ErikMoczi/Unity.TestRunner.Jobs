using System;
using System.Collections.Generic;
using System.Reflection;

namespace WorkSpace.Extensions
{
    public static class TypeExtensions
    {
        public static IEnumerable<Type> GetAllDerivedTypes(this Type type)
        {
            return Assembly.GetAssembly(type).GetAllDerivedTypes(type);
        }
    }
}