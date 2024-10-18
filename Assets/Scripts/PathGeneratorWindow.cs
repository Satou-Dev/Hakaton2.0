using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class PathGeneratorWindow : EditorWindow
{
    private GameObject _roadsObjectParent;
    
    [MenuItem("RaceAI/Generate Path")]
    public static void ShowWindow()
    {
        PathGeneratorWindow wnd = GetWindow<PathGeneratorWindow>();
        wnd.titleContent = new GUIContent("MyEditorWindow");
    }

    private void OnGUI()
    {
        EditorGUILayout.BeginHorizontal();
        
        _roadsObjectParent = (GameObject)EditorGUILayout.ObjectField("Обьект с дорогами", _roadsObjectParent, typeof(GameObject), true);
        
        EditorGUILayout.EndHorizontal();
        
        if (_roadsObjectParent != null)
        {
            if (GUILayout.Button("Сгенерировать путь"))
            {
                SaveChanges();
                
                CallGenerator();
            }
        }
        else
        {
            GUILayout.Label("Не выбран родительский элемент с дорогами");
        }
    }

    private void CallGenerator()
    {
        PathGenerator.StartGenerate(_roadsObjectParent);
    }
}