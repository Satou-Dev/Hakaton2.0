using UnityEditor;
using UnityEngine;

public class PathGeneratorWindow : EditorWindow
{
    string myString = "Введите текст здесь";
    bool groupEnabled;
    bool myBool = true;
    float myFloat = 1.23f;
    
    [MenuItem("Window/My Custom Window")]
    public static void ShowWindow()
    {
        PathGeneratorWindow wnd = GetWindow<PathGeneratorWindow>();
        wnd.titleContent = new GUIContent("MyEditorWindow");
    }

    private void OnGUI()
    {
        // Создаём лейбл
        GUILayout.Label("Настройки", EditorStyles.boldLabel);

        // Поле ввода текста
        myString = EditorGUILayout.TextField("Текстовое поле", myString);

        // Включаем или выключаем группу элементов
        groupEnabled = EditorGUILayout.BeginToggleGroup("Доп. Настройки", groupEnabled);
        myBool = EditorGUILayout.Toggle("Чекбокс", myBool);
        myFloat = EditorGUILayout.Slider("Слайдер", myFloat, 0, 10);
        EditorGUILayout.EndToggleGroup();
    }
}