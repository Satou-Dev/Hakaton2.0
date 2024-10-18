using System;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class Road : MonoBehaviour
{
    private List<MeshFilter> _meshFilters;
    private List<RoadPart> _roadParts;
    
    private void Start()
    {
        InitializeRoadParts();
    }
    
    private void OnDestroy()
    {
        foreach (RoadPart roadPart in _roadParts)
        {
            roadPart?.DestroyScript();
        }
    }

    private void InitializeRoadParts()
    {
        foreach (MeshFilter roadPartMeshFilter in this.GetComponentsInChildren<MeshFilter>())
        {
            roadPartMeshFilter.gameObject.AddComponent<RoadPart>();
        }
    }
}