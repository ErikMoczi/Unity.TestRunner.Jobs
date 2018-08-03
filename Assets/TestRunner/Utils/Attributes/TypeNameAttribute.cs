using System;

namespace TestRunner.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class TypeNameAttribute : Attribute
    {
        public string TypeName { get; }

        public TypeNameAttribute(Type type)
        {
            TypeName = type.ToString();
        }
    }
}