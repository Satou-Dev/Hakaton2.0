using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[ExecuteAlways]
public class RoadCurve : MonoBehaviour
{
    private LineRenderer _lineRenderer;
    
    private void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
    }

    private void OnDestroy()
    {
#if UNITY_EDITOR
        DestroyImmediate(_lineRenderer);
#else
        Destroy(_lineRenderer);
#endif
    }
}