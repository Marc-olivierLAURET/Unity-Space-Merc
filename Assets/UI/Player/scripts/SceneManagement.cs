using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{

    public GameObject Pause;

    private bool is_Paused = false;

    public void loadNewScene(string SceneName) {
        SceneManager.LoadScene(SceneName);
        PauseMenu(false);
    }

    public void quitTheGame() {
        Application.Quit();
    }

    private void PauseGame() {
        Time.timeScale = 0;
    }

    private void ResumeGame() {
        Time.timeScale = 1;
    }

    public void PauseMenu(bool value) {
        if (value) {
            PauseGame();
            Pause.SetActive(true);
            is_Paused = true;
        }
        else {
            ResumeGame();
            Pause.SetActive(false);
            is_Paused = false;
        }
    }

    public bool Get_Pause() {
        return (is_Paused);
    }
}