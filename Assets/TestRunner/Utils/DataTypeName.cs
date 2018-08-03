using TestRunner.Utils.Attributes;
using Unity.Mathematics;

namespace TestRunner.Utils
{
    internal enum DataTypeName
    {
        #region byte

        [TypeName(typeof(byte))] Byte,

        #endregion

        #region double

        [TypeName(typeof(double))] Double,

        #endregion

        #region long

        [TypeName(typeof(long))] Long,

        #endregion

        #region short

        [TypeName(typeof(short))] Short,

        #endregion

        #region int

        [TypeName(typeof(int))] Int,
        [TypeName(typeof(int2))] Int2,
        [TypeName(typeof(int3))] Int3,
        [TypeName(typeof(int4))] Int4,

        #endregion

        #region uint

        [TypeName(typeof(uint))] UInt,
        [TypeName(typeof(uint2))] UInt2,
        [TypeName(typeof(uint3))] UInt3,
        [TypeName(typeof(uint4))] UInt4,

        #endregion

        #region float

        [TypeName(typeof(float))] Float,
        [TypeName(typeof(float2))] Float2,
        [TypeName(typeof(float3))] Float3,
        [TypeName(typeof(float4))] Float4,

        #endregion
    }
}