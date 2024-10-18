using UnityEngine;

[ExecuteAlways]
public class FinishLine : MonoBehaviour
{
    private static FinishLine _instance;
    public static FinishLine Instance => _instance;

    private void Start()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
#if UNITY_EDITOR
            DestroyImmediate(this);
#else
            Destroy(this);
#endif
        }

        CallMethods();
    }

    private void CallMethods()
    {
            
    }
}