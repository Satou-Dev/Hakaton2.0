using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    [Header("����� �����")]
    public int sceneNumber;

    public void Transition()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
