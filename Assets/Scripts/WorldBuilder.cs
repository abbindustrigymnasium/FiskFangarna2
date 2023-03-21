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
    [SerializeField]
    GameObject car;
    public ARPlane plane;
    public Vector3 planeCenter;

    List<ARRaycastHit> raycastHits = new List<ARRaycastHit>();

    public WorldBuilder()
    {
        spawnFishes = new SpawnFishes(this);
    }

    void Update()
    {
        if (raycastManager.Raycast(new Vector2(Screen.height/2, Screen.width/2), raycastHits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinBounds))
        {
            plane = planeManager.GetPlane(raycastHits[0].trackableId);
            if (plane.size.y < 2 && plane.size.x > 3)
            {
                planeCenter = plane.center;
                Debug.Log(planeCenter);
                CreateGameSpace(plane);
                enabled = true;
                spawnFishes.InvokeRepeating("GenerateSpawnLocation", 5f, 3f);
                Debug.Log("Rad 33 i Wordbuilder");
                planeManager.enabled =false ;
               
            }
        }
    }

    void CreateGameSpace(ARPlane plane)
    {
        Instantiate(floorPrefab, new Vector3(plane.transform.position.x,0,plane.transform.position.z), Quaternion.identity);
    }
    
    /*void GenerateSpawnerLocations()
    {
        Vector3 planecenter = plane.center;
        float minX = planecenter.x - plane.size.x / 2;
        float maxX = planecenter.x + plane.size.x / 2;
        for(int i = 0; i < numbersOfSpawners; i++)
        {
            float randomX = Random.Range(minX, maxX);
            Vector3 SpawnAtPosition = new Vector3(randomX, planecenter.y, planecenter.z);
            GameObject tempObject = new GameObject();
            tempObject.transform.position = SpawnAtPosition;
            tempObject.transform.rotation = Quaternion.identity;
            Transform spawnedObject = Instantiate(SpawnerObject, SpawnAtPosition, Quaternion.identity).transform;
            usedSpawnerLocations.Add(spawnedObject);
            spawnerLocations.Add(spawnedObject);
            Destroy(tempObject);
        }
    }*/

    
}
