using System;
using UnityEngine;

[ExecuteAlways]
public class RoadPart : MonoBehaviour
{
    private void Start()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Track");
    }
    
    public void DestroyScript()
    {
        this.gameObject.layer = LayerMask.NameToLayer("Default");
#if UNITY_EDITOR
        DestroyImmediate(this);
#else 
        Destroy(this);
#endif
    }
}