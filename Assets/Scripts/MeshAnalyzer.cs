using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[ExecuteAlways]
public class MeshAnalyzer : MonoBehaviour
{
    private MeshFilter _meshFilter;

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        Vector3 centroid = CalculateCentroid(_meshFilter.sharedMesh);
        Debug.Log("Centroid: " + centroid);
    }

    private Vector3 CalculateCentroid(Mesh mesh)
    {
        Vector3[] vertices = mesh.vertices;
        Vector3 sum = Vector3.zero;

        foreach (var vertex in vertices)
        {
            sum += vertex;
        }

        return sum / vertices.Length;  // Центроид
    }
}