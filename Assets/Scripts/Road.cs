using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[ExecuteAlways]
public class Road : MonoBehaviour
{
    private List<RoadPart> _roadParts;
    
    private void Start()
    {
        InitializeVars();
        InitializeRoadParts();
        SpawnMeshAnalyzer();
    }
    
    private void OnDestroy()
    {
        foreach (RoadPart roadPart in _roadParts.ToList())
        {
            roadPart?.DestroyScript();
            _roadParts.Remove(roadPart);
        }
    }
    
    private void InitializeVars()
    {
        _roadParts = new List<RoadPart>();
    }
    
    private void InitializeRoadParts()
    {
        foreach (MeshFilter roadPartMeshFilter in this.GetComponentsInChildren<MeshFilter>())
        {
            RoadPart roadPartObject = roadPartMeshFilter.gameObject.AddComponent<RoadPart>();
            _roadParts.Add(roadPartObject);
        }
    }

    private void SpawnMeshAnalyzer()
    {
        MeshAnalyzerFabric.SpawnMeshChecker();
    }
}