using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class SpawnFishes : MonoBehaviour
{
    public BucketSpawnScript bucket = new BucketSpawnScript();
    [SerializeField] List<GameObject> fishes = new List<GameObject>();
    List<GameObject> fishesInGame;
    [SerializeField] Camera mainCamera;
    public WorldBuilder worldBuilder;
    Vector3 spawnPosition;
    public float forceAmount = 5f;
    [SerializeField] float destroyTime = 5f;
    [SerializeField] float upForce = 2f;
    [SerializeField] float difficultyAdjuster = 0.25f;

    public float bucketSpawnCount = 0f;
    float elapsedTime;
    int secondsElapsed;
    public float fishScore = 0f;
    bool isPlaying;
    // Start is called before the first frame update

    public SpawnFishes(WorldBuilder wb) => worldBuilder = wb;
    void Start()
    {
        fishesInGame= new List<GameObject>();
        isPlaying = false;
        fishScore = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlaying == true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime >= 1)
            {
                secondsElapsed++;
                elapsedTime = 0;
                //Debug.Log(secondsElapsed);
                if(secondsElapsed % 6 == 0)
                {
                    IncreaseDifficulty();
                    
                }
                
            }
        }
        
    }
    public void GenerateSpawnLocation()
    {
        
        float minX = worldBuilder.planeCenter.x - 2.5f;
        float maxX = worldBuilder.planeCenter.x + 2.5f;
        
        float randomX = Random.Range(minX, maxX);
        
        spawnPosition = new Vector3(randomX, worldBuilder.planeCenter.y, worldBuilder.planeCenter.z);
        if (bucketSpawnCount == 0f)
        {
            bucket.SetSpawnLocation();
        }
        
        SpawnFish();
        bucketSpawnCount++;
            

    }

    public void SpawnFish()
    {
        isPlaying = true;
        int randomFishId = Random.Range(0,fishes.Count);
        GameObject fish = Instantiate(fishes[randomFishId], spawnPosition + Vector3.up, Quaternion.identity);
        fishesInGame.Add(fish);
        Debug.Log("Kamera transform " + mainCamera.transform);
        fish.transform.LookAt(mainCamera.transform.position);
        if (fish.gameObject.tag != "scooter" && fish.gameObject.name != "Al(Clone)")
        {
            fish.transform.Rotate(-90f, 45f, 0f);
        }
        else
        {
            fish.transform.Rotate(0, 45f, 0f);
        }
        

        //fish.transform.LookAt(mainCamera.transform);
        //fish.transform.Rotate(0,-mainCamera.transform.rotation.y, 0);
        //fish.transform.LookAt(transform.position + mainCamera.transform.rotation * Vector3.forward, mainCamera.transform.rotation * Vector3.up);
        Rigidbody fishRb = fish.GetComponent<Rigidbody>();
        if(fishRb != null)
        {
            fishRb.AddForce(-mainCamera.transform.forward * forceAmount, ForceMode.Impulse);
            fishRb.AddForce(Vector3.up * upForce, ForceMode.Impulse);
        }

        Invoke("DestroyFish", destroyTime);
        
    }

    void DestroyFish()
    {
        
        Destroy(fishesInGame[0]);
        fishesInGame.RemoveAt(0);
        fishScore++;
        bucket.changeBucketPrefab();
        Debug.Log(fishScore);
    }

    void IncreaseDifficulty()
    {
            Debug.Log("Increasing difficulty");
            Debug.Log("Old spawn rate: " + worldBuilder.spawnRate);
            worldBuilder.spawnRate = 0.2f;
            Debug.Log("New spawn rate: " + worldBuilder.spawnRate);
        
    }

    
}
