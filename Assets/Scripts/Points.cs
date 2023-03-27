using UnityEngine;
using TMPro;

public class Points : MonoBehaviour
{
    public int totalPoints;
    
    [SerializeField] TMP_Text pointsDisplay;

    void Start()
    {
        totalPoints = 0;
    }

    void Update()
    {
        pointsDisplay.text = totalPoints.ToString();
    }

    public void addPoints(int points)
    {
        totalPoints += points;
    }
}
