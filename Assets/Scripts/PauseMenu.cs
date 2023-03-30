using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] CountDown gameOver;

    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameObject gameUI;

    private void Update()
    {
        if (gameOver.gameEnded)
        { 
            gameUI.SetActive(false);
            pauseMenuUI.SetActive(false);
            Time.timeScale = 0;
        }
    }

    public void pause()
    {
        pauseMenuUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void play()
    {
        pauseMenuUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void exit()
    {
        SceneManager.LoadScene(0);
    }
}
