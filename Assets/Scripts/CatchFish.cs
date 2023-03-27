using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class CatchFish : MonoBehaviour
{
    private Camera camera;
    private Collectable collectable;
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

            if (Physics.Raycast(ray, out hit) && hit.collider && hit.collider.CompareTag("fish"))
            {
                Debug.Log($"{hit.collider.name} Detected",
                    hit.collider.gameObject);
                collectable.Collect();
            }
        }
    }
}

