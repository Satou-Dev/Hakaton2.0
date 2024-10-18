using UnityEngine;
using System.Linq;

[ExecuteAlways]
public class MeshPointDistributor : MonoBehaviour
{
    public int numberOfPoints = 5;
    private MeshFilter _meshFilter;

    private void Start()
    {
        _meshFilter = GetComponent<MeshFilter>();
        Vector3[] distributedPoints = DistributePoints(_meshFilter.mesh, numberOfPoints);

        foreach (var point in distributedPoints)
        {
            Debug.Log("Point: " + point);
            GameObject marker = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            marker.transform.parent = this.transform;
            marker.transform.localPosition = point;
            marker.transform.localScale = Vector3.one;
        }
    }

    private Vector3[] DistributePoints(Mesh mesh, int numPoints)
    {
        Vector3[] vertices = mesh.vertices;
        Vector3[] points = new Vector3[numPoints];

        for (int i = 0; i < numPoints; i++)
        {
            points[i] = vertices[Random.Range(0, vertices.Length)];
        }

        return points;
    }
}