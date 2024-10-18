using System;
using UnityEngine;

[ExecuteAlways]
public class RoadPart : MonoBehaviour
{
    private Road _roadParent;
    
    private void Start()
    {
        if (!_roadParent)
        {
            this.DestroyScript();
        }
        Debug.Log("Initialized");
    }
    
    public void DestroyScript()
    {
        Destroy(this);
    }
}