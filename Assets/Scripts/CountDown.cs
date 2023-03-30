using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class CountDown : MonoBehaviour
{
    public GameObject gameOver;
    
    [SerializeField] SpawnFishes spawnFishes;

    public float currentTime = 0f;
    float startingTime = 120f;

    public bool gameEnded;

    [SerializeField] TMP_Text timerDisplay;

    private void Start()
    {
        currentTime = startingTime;
        gameEnded = false;
    }

    private void Update()
    {
        if (spawnFishes.isPlaying)
        {
            timerDisplay.text = currentTime.ToString();
            if (currentTime <= 0)
            {
                gameOver.SetActive(true);
                currentTime = 0f;
                gameEnded = true;
            }
            else
            {
                currentTime -= 1 * Time.deltaTime;
            }
        }
    }

    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().ToString());
    }

}
