using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneManager : MonoBehaviour
{
    public void loadNewScene(string SceneName) {
        SceneManager.LoadScene(SceneName);
    }

    public void quitTheGame() {
        Application.Quit();
    }
}
