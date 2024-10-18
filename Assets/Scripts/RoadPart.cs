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
        Destroy(this);
    }
}