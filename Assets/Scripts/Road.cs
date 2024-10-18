using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

[ExecuteAlways]
[RequireComponent(typeof(RoadGenerator))]
public class Road : MonoBehaviour
{
    private List<RoadPart> _roadParts;

    [SerializeField] private Structs.TrackParams trackParams;
    
    private void Start()
    {
        InitializeVars();
        InitializeRoadParts();
        SendStartMessage();
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
    
    private void SendStartMessage()
    {
        Debug.Log("Чтобы сгенерировать путь откройте контекстное меню и нажмите сгенерировать");
    }
    
    [ContextMenu("Сгенерировать")]
    private void GeneratePath() => GetComponent<RoadGenerator>().InitializeOnObject(transform);
}