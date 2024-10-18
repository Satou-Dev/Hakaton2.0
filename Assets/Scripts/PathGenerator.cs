using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PathGenerator
{
    private static GameObject _parentObjectMesh;
    private static List<MeshRenderer> _meshRenderers;
    
    public static void StartGenerate(GameObject objectForGenerate)
    {
        _parentObjectMesh = objectForGenerate;
        InitializeListMeshes();
        InitializeWorker();
    }

    private static void InitializeListMeshes()
    {
        _meshRenderers = _parentObjectMesh.GetComponents<MeshRenderer>().ToList();
    }

    private static void InitializeWorker()
    {
        GameObject workerObject = new GameObject();
        workerObject.AddComponent<PathGeneratorWorker>();
        Object.Instantiate(workerObject);
    }
}