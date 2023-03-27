using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] private int points;
    Points totalPoints;

    public void Collect() 
    {
        totalPoints.addPoints(points);
        Destroy(gameObject);
    }
}
