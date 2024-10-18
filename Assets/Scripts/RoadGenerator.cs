using System;
using UnityEditor;
using UnityEngine;

public class RoadGenerator
{
    public static void InitializeOnObject(Transform transform)
    {
        FinishLine finishLine = FinishLine.Instance;
        if (finishLine)
        {
            UnityEngine.Object.Instantiate(Resources.Load("Prefabs/MeshChecker"), transform, true);
        }
        else
        {
            Debug.LogWarning("Нет финишной(стартовой) линии. Добавьте на сцену FinishtLine");
        }
    }
}