using TestCase.Basic.Addition.Simd.Optimalization;
using TestCase.Basic.Division.Simd.Optimalization;
using TestCase.Basic.Multiplication.Simd.Optimalization;
using TestCase.Basic.Subtraction.Simd.Optimalization;
using TestRunner;
using TestRunner.Generator;
using TestRunner.Generator.Interfaces;
using TestRunner.Wrappers.Base;
using TestRunner.Wrappers.Base.Config;
using Unity.Collections;
using Unity.Mathematics;

namespace WorkSpace
{
    public class BasicSimdOptimalizationTest : SampleGenerator
    {
        private const string TestName = nameof(BasicSimdOptimalizationTest);
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

                WorkerTests<int2, int2, int2>.RunIJob(TestName, new SimdAdditionOptimalizationInt2Job(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int2, int2, int2>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationInt2JobParallelFor(), GetData<int2>(DataInt2),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int3, int3, int3>.RunIJob(TestName, new SimdAdditionOptimalizationInt3Job(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int3, int3, int3>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationInt3JobParallelFor(), GetData<int3>(DataInt3),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int4, int4, int4>.RunIJob(TestName, new SimdAdditionOptimalizationInt4Job(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int4, int4, int4>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationInt4JobParallelFor(), GetData<int4>(DataInt4),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint2, uint2, uint2>.RunIJob(TestName, new SimdAdditionOptimalizationUInt2Job(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint2, uint2, uint2>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationUInt2JobParallelFor(), GetData<uint2>(DataUInt2),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdAdditionOptimalizationUInt3Job(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationUInt3JobParallelFor(), GetData<uint3>(DataUInt3),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint4, uint4, uint4>.RunIJob(TestName, new SimdAdditionOptimalizationUInt4Job(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint4, uint4, uint4>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationUInt4JobParallelFor(), GetData<uint4>(DataUInt4),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float2, float2, float2>.RunIJob(TestName, new SimdAdditionOptimalizationFloat2Job(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float2, float2, float2>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationFloat2JobParallelFor(), GetData<float2>(DataFloat2),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdAdditionOptimalizationFloat3Job(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationFloat3JobParallelFor(), GetData<float3>(DataFloat3),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float4, float4, float4>.RunIJob(TestName, new SimdAdditionOptimalizationFloat4Job(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float4, float4, float4>.RunIJobParallelFor(TestName,
                    new SimdAdditionOptimalizationFloat4JobParallelFor(), GetData<float4>(DataFloat4),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                #endregion

                #region Division

                WorkerTests<int2, int2, int2>.RunIJob(TestName, new SimdDivisionOptimalizationInt2Job(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int2, int2, int2>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationInt2JobParallelFor(), GetData<int2>(DataInt2),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int3, int3, int3>.RunIJob(TestName, new SimdDivisionOptimalizationInt3Job(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int3, int3, int3>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationInt3JobParallelFor(), GetData<int3>(DataInt3),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int4, int4, int4>.RunIJob(TestName, new SimdDivisionOptimalizationInt4Job(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int4, int4, int4>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationInt4JobParallelFor(), GetData<int4>(DataInt4),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint2, uint2, uint2>.RunIJob(TestName, new SimdDivisionOptimalizationUInt2Job(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint2, uint2, uint2>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationUInt2JobParallelFor(), GetData<uint2>(DataUInt2),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdDivisionOptimalizationUInt3Job(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationUInt3JobParallelFor(), GetData<uint3>(DataUInt3),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint4, uint4, uint4>.RunIJob(TestName, new SimdDivisionOptimalizationUInt4Job(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint4, uint4, uint4>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationUInt4JobParallelFor(), GetData<uint4>(DataUInt4),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float2, float2, float2>.RunIJob(TestName, new SimdDivisionOptimalizationFloat2Job(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float2, float2, float2>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationFloat2JobParallelFor(), GetData<float2>(DataFloat2),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdDivisionOptimalizationFloat3Job(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationFloat3JobParallelFor(), GetData<float3>(DataFloat3),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float4, float4, float4>.RunIJob(TestName, new SimdDivisionOptimalizationFloat4Job(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float4, float4, float4>.RunIJobParallelFor(TestName,
                    new SimdDivisionOptimalizationFloat4JobParallelFor(), GetData<float4>(DataFloat4),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                #endregion

                #region Multiplication

                WorkerTests<int2, int2, int2>.RunIJob(TestName, new SimdMultiplicationOptimalizationInt2Job(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int2, int2, int2>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationInt2JobParallelFor(), GetData<int2>(DataInt2),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int3, int3, int3>.RunIJob(TestName, new SimdMultiplicationOptimalizationInt3Job(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int3, int3, int3>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationInt3JobParallelFor(), GetData<int3>(DataInt3),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int4, int4, int4>.RunIJob(TestName, new SimdMultiplicationOptimalizationInt4Job(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int4, int4, int4>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationInt4JobParallelFor(), GetData<int4>(DataInt4),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint2, uint2, uint2>.RunIJob(TestName, new SimdMultiplicationOptimalizationUInt2Job(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint2, uint2, uint2>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationUInt2JobParallelFor(), GetData<uint2>(DataUInt2),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdMultiplicationOptimalizationUInt3Job(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationUInt3JobParallelFor(), GetData<uint3>(DataUInt3),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint4, uint4, uint4>.RunIJob(TestName, new SimdMultiplicationOptimalizationUInt4Job(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint4, uint4, uint4>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationUInt4JobParallelFor(), GetData<uint4>(DataUInt4),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float2, float2, float2>.RunIJob(TestName, new SimdMultiplicationOptimalizationFloat2Job(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float2, float2, float2>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationFloat2JobParallelFor(), GetData<float2>(DataFloat2),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdMultiplicationOptimalizationFloat3Job(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationFloat3JobParallelFor(), GetData<float3>(DataFloat3),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float4, float4, float4>.RunIJob(TestName, new SimdMultiplicationOptimalizationFloat4Job(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float4, float4, float4>.RunIJobParallelFor(TestName,
                    new SimdMultiplicationOptimalizationFloat4JobParallelFor(), GetData<float4>(DataFloat4),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                #endregion

                #region Subtraction

                WorkerTests<int2, int2, int2>.RunIJob(TestName, new SimdSubtractionOptimalizationInt2Job(),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int2, int2, int2>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationInt2JobParallelFor(), GetData<int2>(DataInt2),
                    GetData<int2>(DataInt2), GetData<int2>(DataInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int3, int3, int3>.RunIJob(TestName, new SimdSubtractionOptimalizationInt3Job(),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int3, int3, int3>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationInt3JobParallelFor(), GetData<int3>(DataInt3),
                    GetData<int3>(DataInt3), GetData<int3>(DataInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<int4, int4, int4>.RunIJob(TestName, new SimdSubtractionOptimalizationInt4Job(),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<int4, int4, int4>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationInt4JobParallelFor(), GetData<int4>(DataInt4),
                    GetData<int4>(DataInt4), GetData<int4>(DataInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint2, uint2, uint2>.RunIJob(TestName, new SimdSubtractionOptimalizationUInt2Job(),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint2, uint2, uint2>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationUInt2JobParallelFor(), GetData<uint2>(DataUInt2),
                    GetData<uint2>(DataUInt2), GetData<uint2>(DataUInt2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint3, uint3, uint3>.RunIJob(TestName, new SimdSubtractionOptimalizationUInt3Job(),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint3, uint3, uint3>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationUInt3JobParallelFor(), GetData<uint3>(DataUInt3),
                    GetData<uint3>(DataUInt3), GetData<uint3>(DataUInt3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<uint4, uint4, uint4>.RunIJob(TestName, new SimdSubtractionOptimalizationUInt4Job(),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<uint4, uint4, uint4>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationUInt4JobParallelFor(), GetData<uint4>(DataUInt4),
                    GetData<uint4>(DataUInt4), GetData<uint4>(DataUInt4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float2, float2, float2>.RunIJob(TestName, new SimdSubtractionOptimalizationFloat2Job(),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float2, float2, float2>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationFloat2JobParallelFor(), GetData<float2>(DataFloat2),
                    GetData<float2>(DataFloat2), GetData<float2>(DataFloat2),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float3, float3, float3>.RunIJob(TestName, new SimdSubtractionOptimalizationFloat3Job(),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float3, float3, float3>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationFloat3JobParallelFor(), GetData<float3>(DataFloat3),
                    GetData<float3>(DataFloat3), GetData<float3>(DataFloat3),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                WorkerTests<float4, float4, float4>.RunIJob(TestName, new SimdSubtractionOptimalizationFloat4Job(),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJob(Allocator.Persistent, true)),
                WorkerTests<float4, float4, float4>.RunIJobParallelFor(TestName,
                    new SimdSubtractionOptimalizationFloat4JobParallelFor(), GetData<float4>(DataFloat4),
                    GetData<float4>(DataFloat4), GetData<float4>(DataFloat4),
                    new WorkConfigIJobParallelFor(Allocator.Persistent, true)),

                #endregion
            };
        }
    }
}