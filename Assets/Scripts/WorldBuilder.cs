using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class WorldBuilder : MonoBehaviour
{
    [SerializeField]
    ARPlaneManager planeManager;
    [SerializeField]
    ARRaycastManager raycastManager;
    [SerializeField]
    GameObject floorPrefab;
    [SerializeField]
    GameObject car;

    List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    void Update()
    {
        if (raycastManager.Raycast(new Vector2(Screen.height/2, Screen.width/2), raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds))
        {
            ARPlane plane = planeManager.GetPlane(raycastHits[0].trackableId);
            if (plane.size.y > 2 && plane.size.x > 2)
            {
                CreateGameSpace(plane);
                enabled = false;
            }
        }
    }

    void CreateGameSpace(ARPlane plane)
    {
        Instantiate(floorPrefab, plane.center, Quaternion.identity);
        car.transform.position = plane.center + Vector3.up;
        car.SetActive(true);
    }
}
