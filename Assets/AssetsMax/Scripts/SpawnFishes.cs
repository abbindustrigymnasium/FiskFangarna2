using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnFishes : MonoBehaviour
{
    [SerializeField] List<GameObject> fishes = new List<GameObject>();
    public WorldBuilder worldBuilder;
    Vector3 spawnPosition;
    [SerializeField] float spawnRate;
    public float forceAmount = 5f;
    // Start is called before the first frame update

    public SpawnFishes(WorldBuilder wb)
    {
        worldBuilder = wb;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void GenerateSpawnLocation()
    {
        
        Debug.Log("Rad 30");
        float minX = worldBuilder.planeCenter.x - worldBuilder.plane.size.x / 1.5f;
        float maxX = worldBuilder.planeCenter.x + worldBuilder.plane.size.x / 1.5f;
        Debug.Log("Rad 33");
        float randomX = Random.Range(minX, maxX);
        Debug.Log("Rad 35");
        spawnPosition = new Vector3(randomX, worldBuilder.planeCenter.y, worldBuilder.planeCenter.z);
        Debug.Log("I GenerateSpaw");
        SpawnFish();
            

    }

    public void SpawnFish()
    {
        int randomFishId = Random.Range(0,fishes.Count);
        GameObject fish = Instantiate(fishes[randomFishId], spawnPosition + Vector3.up, Quaternion.identity);
        fish.transform.Rotate(0, 0, 90);
        fish.transform.rotation = Quaternion.Euler(45f, 0f, 0f);
        Rigidbody fishRb = fish.GetComponent<Rigidbody>();
        if(fishRb != null)
        {
            fishRb.AddForce(-fish.transform.forward * forceAmount, ForceMode.Impulse);
        }
        Debug.Log("Skapar obejekt");
    }

    
}
