using System;
using UnityEngine;

[ExecuteAlways]
public class MeshChecker : MonoBehaviour
{
    private Bounds _bounds;
    private BoxCollider _boxCollider;
    private LayerMask _layerMask;
    
    private void Start()
    {
        _boxCollider = GetComponent<BoxCollider>();
        _bounds = _boxCollider.bounds;
        _layerMask = (LayerMask)LayerMask.NameToLayer("Track");
    }

    private void FixedUpdate()
    {
        
    }

    private bool CheckVertexInBoundingBox(Vector3 vertexPos)
    {
        return _bounds.Contains(vertexPos);
    }
}