using TestCase.Terrain.Job;
using TestCase.Terrain.JobParallelFor;
using TestCase.Terrain.Plain;
using TestCase.Terrain.SystemParallelFor;
using TestWrapper;
using TestWrapper.Config.Data;
using TestWrapper.Config.Data.Interfaces;
using TestWrapper.Config.Worker;
using TestWrapper.Facades;
using TestWrapper.Generator;
using TestWrapper.Generator.Interfaces;
using Unity.Collections;
using UnityEngine;
using WorkSpace.Provider.Containers;
using WorkSpace.Provider.Settings;

namespace WorkSpace.Tests.MeshTest
{
    internal sealed class TerrainTest : SampleGenerator
    {
        public override string TestName()
        {
            return nameof(TerrainTest);
        }

        public override ISampleConfig[] InitSampleConfigs()
        {
            return new ISampleConfig[]
            {
                new SampleConfig(typeof(Vector3), TypeConfig.DataVector3),
                new SampleConfig(typeof(int), TypeConfig.DataInt1),
            };
        }

        public override IWorkFacade[] InitWorkFacades(IInputDataContainer inputDataContainer, int dataSize)
        {
            return new[]
            {
                #region Plain

                WorkerFactory<Vector3[], int[]>.Create<SeparateAllPlain>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<Vector3[], int[]>.Create<SeparateVerticesTrianglesPlain>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<Vector3[], int[]>.Create<AllJoinPlain>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),
                WorkerFactory<Vector3[], int[]>.Create<AllJoinSingleForPlain>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),

                #endregion

                #region Job

                WorkerFactory<NativeArray<Vector3>, NativeArray<int>>.Create<SeparateAllJob>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<Vector3>, NativeArray<int>>.Create<SeparateVerticesTrianglesJob>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<Vector3>, NativeArray<int>>.Create<AllJoinJob>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),
                WorkerFactory<NativeArray<Vector3>, NativeArray<int>>.Create<AllJoinSingleForJob>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJob(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),

                #endregion

                #region JobParallelFor

                WorkerFactory<NativeArray<Vector3>, NativeArray<int>>.Create<AllJoinSingleForJobParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigIJobParallelFor(),
                    new IDataConfig[]
                    {
                        new DataConfigUnityCollection(Allocator.Persistent),
                        new DataConfigUnityCollection(Allocator.Persistent),
                    }
                ),

                #endregion

                #region SystemParallelFor

                WorkerFactory<Vector3[], int[]>.Create<AllJoinSingleForSystemParallelFor>(
                    TestName(),
                    inputDataContainer.GetData<Vector3>(TypeConfig.DataVector3),
                    inputDataContainer.GetData<int>(TypeConfig.DataInt1),
                    new WorkConfigDefault(),
                    new IDataConfig[]
                    {
                        new DataConfigDefault(),
                        new DataConfigDefault(),
                    }
                ),

                #endregion
            };
        }
    }
}