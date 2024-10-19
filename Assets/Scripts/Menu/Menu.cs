using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

    [Header("Номер сцены")]
    public int sceneNumber;

    public void Transition()
    {
        SceneManager.LoadScene(sceneNumber);
    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Выход");
    }
}
