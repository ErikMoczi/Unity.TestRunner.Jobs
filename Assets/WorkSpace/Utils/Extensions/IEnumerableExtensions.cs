using System.Collections.Generic;

namespace WorkSpace.Utils.Extensions
{
    internal static class IEnumerableExtensions
    {
        public static HashSet<T> ToHashSet<T>(this IEnumerable<T> source)
        {
            return new HashSet<T>(source);
        }
    }
}