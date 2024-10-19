using UnityEngine;
using UnityEngine.SceneManagement;

public class Start : MonoBehaviour {

    [Header("Номер сцены")]
    public int sceneNumber;

    public void Transition()
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
