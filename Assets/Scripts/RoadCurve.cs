using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[ExecuteAlways]
public class RoadCurve : MonoBehaviour
{
    private LineRenderer lineRenderer;
    private List<Vector3> curvePoints = new List<Vector3>();

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        // Инициализируем точки кривой, используя геометрию мешей
        ExtractCurveFromMeshes();

        // Рисуем линию по извлечённым точкам
        DrawCurve();
    }

    private void ExtractCurveFromMeshes()
    {
        // Обходим все MeshFilter в дочерних объектах
        foreach (MeshFilter meshFilter in GetComponentsInChildren<MeshFilter>())
        {
            Mesh mesh = meshFilter.sharedMesh;

            // Извлекаем вершины меша в локальной системе координат
            Vector3[] vertices = mesh.vertices;

            // Трансформируем вершины в мировые координаты и добавляем в список
            foreach (Vector3 vertex in vertices)
            {
                Vector3 worldPosition = meshFilter.transform.TransformPoint(vertex);
                curvePoints.Add(worldPosition);
            }
        }

        // Опционально: Убираем дубликаты точек для чистоты кривой
        RemoveDuplicatePoints();
    }

    // Удаляет дубликаты точек с заданной точностью
    private void RemoveDuplicatePoints(float tolerance = 0.01f)
    {
        List<Vector3> uniquePoints = new List<Vector3>();

        foreach (Vector3 point in curvePoints)
        {
            bool isDuplicate = uniquePoints.Exists(p => Vector3.Distance(p, point) < tolerance);
            if (!isDuplicate)
            {
                uniquePoints.Add(point);
            }
        }

        curvePoints = uniquePoints;
    }

    // Отрисовываем линию через точки кривой
    private void DrawCurve()
    {
        lineRenderer.positionCount = curvePoints.Count;

        for (int i = 0; i < curvePoints.Count; i++)
        {
            lineRenderer.SetPosition(i, curvePoints[i]);
        }

        lineRenderer.startWidth = 0.5f;
        lineRenderer.endWidth = 0.5f;
        lineRenderer.loop = true; // Закольцовываем линию при необходимости
    }
}