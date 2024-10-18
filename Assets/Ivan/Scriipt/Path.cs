using UnityEngine;
using System.Collections.Generic;

public class Path : MonoBehaviour
{
    public Color lineColor;

    private List<Transform> nodes = new List<Transform>();

    void OnDrawGizmos()
    {
        Gizmos.color = lineColor;

        // Получаем все дочерние объекты
        Transform[] pathTransforms = GetComponentsInChildren<Transform>();
        nodes.Clear();

        // Добавляем только дочерние объекты, кроме корневого
        foreach (Transform t in pathTransforms)
        {
            if (t != this.transform)
            {
                nodes.Add(t);
            }
        }

        // Отрисовка линий между узлами
        if (nodes.Count < 2) return; // Если узлов меньше двух, то линий рисовать не надо

        for (int i = 0; i < nodes.Count; i++)
        {
            // Определяем предыдущий узел, для замыкания на последний узел при i == 0
            Vector3 previousNode = nodes[i == 0 ? nodes.Count - 1 : i - 1].position;
            Vector3 currentNode = nodes[i].position;

            Gizmos.DrawLine(previousNode, currentNode);
            Gizmos.DrawWireSphere(currentNode, 0.5f);
        }
    }
}
