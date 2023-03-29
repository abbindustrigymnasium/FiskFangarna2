using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEditor;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class WorldBuilder : MonoBehaviour
{
    public SpawnFishes spawnFishes;
    [SerializeField]
    ARPlaneManager planeManager;
    [SerializeField]
    ARRaycastManager raycastManager;
    [SerializeField]
    GameObject floorPrefab;
    public ARPlane plane;
    public Vector3 planeCenter;
    [SerializeField] float spawnDelayTime = 5f;
    public float spawnRate;
    List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    public WorldBuilder()
    {
        spawnFishes = new SpawnFishes(this);
    }
    private void Start()
    {
        
    }

    void Update()
    {
        if (raycastManager.Raycast(new Vector2(Screen.height/2, Screen.width/2), raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds))
        {
            //Debug.Log("Storlek x: " + plane.size.x + " Storlek y: " + plane.size.y);
            //Debug.Log("Storlek som den ska vara är > 3, och mindre än 2")

            plane = planeManager.GetPlane(raycastHits[0].trackableId);
            if (plane.size.y > 1 && plane.size.x > 1)
            {
                planeCenter = plane.center;
                Debug.Log(planeCenter);
                CreateGameSpace(plane);
                enabled = false;
                spawnFishes.InvokeRepeating("GenerateSpawnLocation", spawnDelayTime, spawnRate);
                Debug.Log("HITTAT PLANE");
                planeManager.enabled =false ;
               
            }
        }
    }

    void CreateGameSpace(ARPlane plane)
    {
        Instantiate(floorPrefab, new Vector3(plane.transform.position.x,0,plane.transform.position.z), Quaternion.identity);
    } 
}
