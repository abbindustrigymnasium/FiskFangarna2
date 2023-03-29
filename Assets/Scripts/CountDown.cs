using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountDown : MonoBehaviour
{
    public GameObject gameOver;
    Points points;

    float currentTime = 0f;
    float startingTime = 120f;

    [SerializeField] TMP_Text timerDisplay;
    [SerializeField] TMP_Text totalPoints;

    private void Start()
    {
        currentTime = startingTime;
    }

    private void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        timerDisplay.text = currentTime.ToString();
        if( currentTime <= 0)
        {
            gameOver.SetActive(true);
            totalPoints.text = points.totalPoints.ToString();
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

}
