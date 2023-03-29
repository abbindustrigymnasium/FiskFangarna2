using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngineInternal;

public class CatchFish : MonoBehaviour
{
    [SerializeField] private Camera camera;

    [SerializeField] Points totalPoints;

    private int points;
    void Start()
    {
        camera = Camera.main;
    }

    void Update()
    {
        DetectFish();
    }

    public void DetectFish()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = camera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.Log("Hit");

            if (Physics.Raycast(ray, out hit) && hit.collider && hit.collider.CompareTag("fish1"))
            {
                points = 1;
                Debug.Log("Hit Fish1");
                Collect(points);
                Destroy(hit.collider.gameObject);
            }
            else if(Physics.Raycast(ray, out hit) && hit.collider && hit.collider.CompareTag("fish2"))
            {
                points = 3;
                Debug.Log("Hit Fish2");
                Collect(points);
                Destroy(hit.collider.gameObject);
            }
            else if (Physics.Raycast(ray, out hit) && hit.collider && hit.collider.CompareTag("fish3"))
            {
                points = 5;
                Debug.Log("Hit Fish3");
                Collect(points);
                Destroy(hit.collider.gameObject);

            }
            else if (Physics.Raycast(ray, out hit) && hit.collider && hit.collider.CompareTag("scooter"))
            {
                points = -3;
                Debug.Log("Hit Scooter");
                Collect(points);
                Destroy(hit.collider.gameObject);
            }
        }
    }
    public void Collect(int points)
    {
        Debug.Log("collected fish");
        totalPoints.addPoints(points);
    }
}

