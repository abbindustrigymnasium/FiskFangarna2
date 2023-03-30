using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountDown : MonoBehaviour
{
    public GameObject gameOver;

    public float currentTime = 0f;
    float startingTime = 120f;

    [SerializeField] TMP_Text timerDisplay;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        timerDisplay.text = currentTime.ToString();
        if( currentTime <= 0)
        {
            gameOver.SetActive(true);
            currentTime = 0f;
        }
        else
        {
            currentTime -= 1 * Time.deltaTime;
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

}
