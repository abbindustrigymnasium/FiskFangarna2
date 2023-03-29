using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject howToPlay;
    public GameObject aboutUs;

    public void play()
    {
        SceneManager.LoadScene(1);
    }

    public void tutorial()
    {
        mainMenu.SetActive(false);
        howToPlay.SetActive(true);
    }

    public void about()
    {
        aboutUs.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void returnToMain()
    {
        aboutUs.SetActive(false);
        howToPlay.SetActive(false);
        mainMenu.SetActive(true);
    }
    public void exitGame()
    {
        Application.Quit();
    }
}
