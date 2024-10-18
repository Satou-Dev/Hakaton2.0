using System;
using UnityEngine;

[ExecuteAlways]
public class RoadPart : MonoBehaviour
{
    private void Start()
    {
        Debug.Log("Initialized");
    }
    
    public void DestroyScript()
    {
#if UNITY_EDITOR
        DestroyImmediate(this);
#else 
        Destroy(this);
#endif
    }
}