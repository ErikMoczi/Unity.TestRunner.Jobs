using System;
using TestRunner.Utils.Attributes;
using TestRunner.Utils.Extensions;

namespace TestRunner.Utils
{
    internal static class EnumHelper
    {
        public static T GetEnumFromString<T>(string value) where T : struct
        {
            if (Enum.IsDefined(typeof(T), value))
            {
                return (T) Enum.Parse(typeof(T), value, true);
            }
            else
            {
                var enumNames = Enum.GetNames(typeof(T));
                foreach (var enumName in enumNames)
                {
                    var e = Enum.Parse(typeof(T), enumName);
                    if (value == ((Enum) e).GetAttribute<TypeNameAttribute>().TypeName)
                    {
                        return (T) e;
                    }
                }
            }

            throw new ArgumentException(
                $"The value '{value}' of enum '{typeof(T)}' does not match a valid enum name or description."
            );
        }
    }
}