using TestRunner.Utils.Attributes;
using Unity.Mathematics;

namespace TestRunner.Utils
{
    internal enum DataTypeName
    {
        #region Int

        [TypeName(typeof(int))] Int,
        [TypeName(typeof(int2))] Int2,
        [TypeName(typeof(int3))] Int3,
        [TypeName(typeof(int4))] Int4,

        #endregion

        #region Float

        [TypeName(typeof(float))] Float,
        [TypeName(typeof(float2))] Float2,
        [TypeName(typeof(float3))] Float3,
        [TypeName(typeof(float4))] Float4,

        #endregion
    }
}