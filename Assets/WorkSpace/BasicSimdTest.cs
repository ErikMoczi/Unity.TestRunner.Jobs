using TestCase.Basic.Addition.Simd;
using TestCase.Basic.Division.Simd;
using TestCase.Basic.Multiplication.Simd;
using TestCase.Basic.Subtraction.Simd;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;

namespace WorkSpace
{
    public class BasicSimdTest : SampleGenerator
    {
        private const string TestName = nameof(BasicSimdTest);
        private const string DataInt2 = "DataInt2";
        private const string DataInt3 = "DataInt3";
        private const string DataInt4 = "DataInt4";
        private const string DataFloat2 = "DataFloat2";
        private const string DataFloat3 = "DataFloat3";
        private const string DataFloat4 = "DataFloat4";
        private const string DataUInt2 = "DataUInt2";
        private const string DataUInt3 = "DataUInt3";
        private const string DataUInt4 = "DataUInt4";

        protected override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(int2), DataInt2),
                new SampleConfig(typeof(int3), DataInt3),
                new SampleConfig(typeof(int4), DataInt4),
                new SampleConfig(typeof(float2), DataFloat2),
                new SampleConfig(typeof(float3), DataFloat3),
                new SampleConfig(typeof(float4), DataFloat4),
                new SampleConfig(typeof(uint2), DataUInt2),
                new SampleConfig(typeof(uint3), DataUInt3),
                new SampleConfig(typeof(uint4), DataUInt4),
            };
        }

        protected override IWorkWrapper[] InitWorkWrappers()
        {
            return new[]
            {
                #region Addition

                WorkerTests<int2, int2, int2>.RunIJob(TestName, new SimdAdditionInt2Job(), GetData<int2>(DataInt2),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int2, int2, int2>.RunIJobParallelFor(TestName, new SimdAdditionInt2JobParallelFor(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int2, int2, int2>.RunINonJob(TestName, new SimdAdditionInt2NonJob(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2)),

                WorkerTests<int3, int3, int3>.RunIJob(TestName, new SimdAdditionInt3Job(), GetData<int3>(DataInt3),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int3, int3, int3>.RunIJobParallelFor(TestName, new SimdAdditionInt3JobParallelFor(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int3, int3, int3>.RunINonJob(TestName, new SimdAdditionInt3NonJob(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3)),

                WorkerTests<int4, int4, int4>.RunIJob(TestName, new SimdAdditionInt4Job(), GetData<int4>(DataInt4),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int4, int4, int4>.RunIJobParallelFor(TestName, new SimdAdditionInt4JobParallelFor(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int4, int4, int4>.RunINonJob(TestName, new SimdAdditionInt4NonJob(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4)),

                WorkerTests<uint2, uint2, uint2>.RunIJob(TestName, new SimdAdditionUInt2Job(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint2, uint2, uint2>.RunIJobParallelFor(TestName, new SimdAdditionUInt2JobParallelFor(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint2, uint2, uint2>.RunINonJob(TestName, new SimdAdditionUInt2NonJob(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2)),

                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdAdditionUInt3Job(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName, new SimdAdditionUInt3JobParallelFor(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint3, uint3, uint3>.RunINonJob(TestName, new SimdAdditionUInt3NonJob(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3)),

                WorkerTests<uint4, uint4, uint4>.RunIJob(TestName, new SimdAdditionUInt4Job(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint4, uint4, uint4>.RunIJobParallelFor(TestName, new SimdAdditionUInt4JobParallelFor(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint4, uint4, uint4>.RunINonJob(TestName, new SimdAdditionUInt4NonJob(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4)),

                WorkerTests<float2, float2, float2>.RunIJob(TestName, new SimdAdditionFloat2Job(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float2, float2, float2>.RunIJobParallelFor(TestName, new SimdAdditionFloat2JobParallelFor(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float2, float2, float2>.RunINonJob(TestName, new SimdAdditionFloat2NonJob(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2)),

                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdAdditionFloat3Job(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName, new SimdAdditionFloat3JobParallelFor(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float3, float3, float3>.RunINonJob(TestName, new SimdAdditionFloat3NonJob(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3)),

                WorkerTests<float4, float4, float4>.RunIJob(TestName, new SimdAdditionFloat4Job(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float4, float4, float4>.RunIJobParallelFor(TestName, new SimdAdditionFloat4JobParallelFor(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float4, float4, float4>.RunINonJob(TestName, new SimdAdditionFloat4NonJob(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4)),

                #endregion

                #region Division

                WorkerTests<int2, int2, int2>.RunIJob(TestName, new SimdDivisionInt2Job(), GetData<int2>(DataInt2),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int2, int2, int2>.RunIJobParallelFor(TestName, new SimdDivisionInt2JobParallelFor(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int2, int2, int2>.RunINonJob(TestName, new SimdDivisionInt2NonJob(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2)),

                WorkerTests<int3, int3, int3>.RunIJob(TestName, new SimdDivisionInt3Job(), GetData<int3>(DataInt3),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int3, int3, int3>.RunIJobParallelFor(TestName, new SimdDivisionInt3JobParallelFor(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int3, int3, int3>.RunINonJob(TestName, new SimdDivisionInt3NonJob(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3)),

                WorkerTests<int4, int4, int4>.RunIJob(TestName, new SimdDivisionInt4Job(), GetData<int4>(DataInt4),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int4, int4, int4>.RunIJobParallelFor(TestName, new SimdDivisionInt4JobParallelFor(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int4, int4, int4>.RunINonJob(TestName, new SimdDivisionInt4NonJob(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4)),

                WorkerTests<uint2, uint2, uint2>.RunIJob(TestName, new SimdDivisionUInt2Job(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint2, uint2, uint2>.RunIJobParallelFor(TestName, new SimdDivisionUInt2JobParallelFor(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint2, uint2, uint2>.RunINonJob(TestName, new SimdDivisionUInt2NonJob(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2)),

                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdDivisionUInt3Job(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName, new SimdDivisionUInt3JobParallelFor(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint3, uint3, uint3>.RunINonJob(TestName, new SimdDivisionUInt3NonJob(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3)),

                WorkerTests<uint4, uint4, uint4>.RunIJob(TestName, new SimdDivisionUInt4Job(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint4, uint4, uint4>.RunIJobParallelFor(TestName, new SimdDivisionUInt4JobParallelFor(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint4, uint4, uint4>.RunINonJob(TestName, new SimdDivisionUInt4NonJob(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4)),

                WorkerTests<float2, float2, float2>.RunIJob(TestName, new SimdDivisionFloat2Job(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float2, float2, float2>.RunIJobParallelFor(TestName, new SimdDivisionFloat2JobParallelFor(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float2, float2, float2>.RunINonJob(TestName, new SimdDivisionFloat2NonJob(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2)),

                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdDivisionFloat3Job(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName, new SimdDivisionFloat3JobParallelFor(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float3, float3, float3>.RunINonJob(TestName, new SimdDivisionFloat3NonJob(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3)),

                WorkerTests<float4, float4, float4>.RunIJob(TestName, new SimdDivisionFloat4Job(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float4, float4, float4>.RunIJobParallelFor(TestName, new SimdDivisionFloat4JobParallelFor(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float4, float4, float4>.RunINonJob(TestName, new SimdDivisionFloat4NonJob(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4)),

                #endregion

                #region Multiplication

                WorkerTests<int2, int2, int2>.RunIJob(TestName, new SimdMultiplicationInt2Job(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int2, int2, int2>.RunIJobParallelFor(TestName, new SimdMultiplicationInt2JobParallelFor(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int2, int2, int2>.RunINonJob(TestName, new SimdMultiplicationInt2NonJob(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2)),

                WorkerTests<int3, int3, int3>.RunIJob(TestName, new SimdMultiplicationInt3Job(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int3, int3, int3>.RunIJobParallelFor(TestName, new SimdMultiplicationInt3JobParallelFor(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int3, int3, int3>.RunINonJob(TestName, new SimdMultiplicationInt3NonJob(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3)),

                WorkerTests<int4, int4, int4>.RunIJob(TestName, new SimdMultiplicationInt4Job(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int4, int4, int4>.RunIJobParallelFor(TestName, new SimdMultiplicationInt4JobParallelFor(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int4, int4, int4>.RunINonJob(TestName, new SimdMultiplicationInt4NonJob(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4)),

                WorkerTests<uint2, uint2, uint2>.RunIJob(TestName, new SimdMultiplicationUInt2Job(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint2, uint2, uint2>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationUInt2JobParallelFor(), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    GetData<uint2>(DataUInt2), new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint2, uint2, uint2>.RunINonJob(TestName, new SimdMultiplicationUInt2NonJob(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2)),

                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdMultiplicationUInt3Job(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationUInt3JobParallelFor(), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    GetData<uint3>(DataUInt3), new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint3, uint3, uint3>.RunINonJob(TestName, new SimdMultiplicationUInt3NonJob(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3)),

                WorkerTests<uint4, uint4, uint4>.RunIJob(TestName, new SimdMultiplicationUInt4Job(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint4, uint4, uint4>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationUInt4JobParallelFor(), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    GetData<uint4>(DataUInt4), new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint4, uint4, uint4>.RunINonJob(TestName, new SimdMultiplicationUInt4NonJob(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4)),

                WorkerTests<float2, float2, float2>.RunIJob(TestName, new SimdMultiplicationFloat2Job(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float2, float2, float2>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationFloat2JobParallelFor(), GetData<float2>(DataFloat2),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float2, float2, float2>.RunINonJob(TestName, new SimdMultiplicationFloat2NonJob(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2)),

                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdMultiplicationFloat3Job(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationFloat3JobParallelFor(), GetData<float3>(DataFloat3),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float3, float3, float3>.RunINonJob(TestName, new SimdMultiplicationFloat3NonJob(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3)),

                WorkerTests<float4, float4, float4>.RunIJob(TestName, new SimdMultiplicationFloat4Job(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float4, float4, float4>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationFloat4JobParallelFor(), GetData<float4>(DataFloat4),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float4, float4, float4>.RunINonJob(TestName, new SimdMultiplicationFloat4NonJob(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4)),

                #endregion

                #region Subtraction

                WorkerTests<int2, int2, int2>.RunIJob(TestName, new SimdSubtractionInt2Job(), GetData<int2>(DataInt2),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int2, int2, int2>.RunIJobParallelFor(TestName, new SimdSubtractionInt2JobParallelFor(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int2, int2, int2>.RunINonJob(TestName, new SimdSubtractionInt2NonJob(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2)),

                WorkerTests<int3, int3, int3>.RunIJob(TestName, new SimdSubtractionInt3Job(), GetData<int3>(DataInt3),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int3, int3, int3>.RunIJobParallelFor(TestName, new SimdSubtractionInt3JobParallelFor(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int3, int3, int3>.RunINonJob(TestName, new SimdSubtractionInt3NonJob(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3)),

                WorkerTests<int4, int4, int4>.RunIJob(TestName, new SimdSubtractionInt4Job(), GetData<int4>(DataInt4),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<int4, int4, int4>.RunIJobParallelFor(TestName, new SimdSubtractionInt4JobParallelFor(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<int4, int4, int4>.RunINonJob(TestName, new SimdSubtractionInt4NonJob(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4)),

                WorkerTests<uint2, uint2, uint2>.RunIJob(TestName, new SimdSubtractionUInt2Job(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint2, uint2, uint2>.RunIJobParallelFor(TestName, new SimdSubtractionUInt2JobParallelFor(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint2, uint2, uint2>.RunINonJob(TestName, new SimdSubtractionUInt2NonJob(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2)),

                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdSubtractionUInt3Job(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName, new SimdSubtractionUInt3JobParallelFor(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint3, uint3, uint3>.RunINonJob(TestName, new SimdSubtractionUInt3NonJob(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3)),

                WorkerTests<uint4, uint4, uint4>.RunIJob(TestName, new SimdSubtractionUInt4Job(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<uint4, uint4, uint4>.RunIJobParallelFor(TestName, new SimdSubtractionUInt4JobParallelFor(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<uint4, uint4, uint4>.RunINonJob(TestName, new SimdSubtractionUInt4NonJob(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4)),

                WorkerTests<float2, float2, float2>.RunIJob(TestName, new SimdSubtractionFloat2Job(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float2, float2, float2>.RunIJobParallelFor(TestName,
                    new SimdSubtractionFloat2JobParallelFor(), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    GetData<float2>(DataFloat2), new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float2, float2, float2>.RunINonJob(TestName, new SimdSubtractionFloat2NonJob(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2)),

                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdSubtractionFloat3Job(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName,
                    new SimdSubtractionFloat3JobParallelFor(), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    GetData<float3>(DataFloat3), new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float3, float3, float3>.RunINonJob(TestName, new SimdSubtractionFloat3NonJob(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3)),

                WorkerTests<float4, float4, float4>.RunIJob(TestName, new SimdSubtractionFloat4Job(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJob(Allocator.Persistent)),
                WorkerTests<float4, float4, float4>.RunIJobParallelFor(TestName,
                    new SimdSubtractionFloat4JobParallelFor(), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    GetData<float4>(DataFloat4), new WorkConfigIJobParallelFor(Allocator.Persistent)),
                WorkerTests<float4, float4, float4>.RunINonJob(TestName, new SimdSubtractionFloat4NonJob(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4)),

                #endregion
            };
        }
    }
}