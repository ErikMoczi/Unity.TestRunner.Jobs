﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace WorkSpace.Utils.Extensions
{
    internal static class AssemblyExtensions
    {
        public static IEnumerable<Type> GetAllDerivedTypes(this Assembly assembly, Type type)
        {
            return assembly.GetTypes().Where(t => t != type && type.IsAssignableFrom(t) && t.IsClass && !t.IsAbstract);
        }
    }
}