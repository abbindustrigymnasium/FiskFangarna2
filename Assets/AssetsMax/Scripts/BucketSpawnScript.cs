using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BucketSpawnScript : MonoBehaviour
{
    public SpawnFishes spawnFishes;
    [SerializeField] List<GameObject> buckets = new List<GameObject>();
    GameObject bucket;
    Transform bucketLocation;
    bool destroyBucket;
    // Start is called before the first frame update
    void Start()
    {
        destroyBucket = true;
    }

    // Update is called once per frame
    public void SetSpawnLocation()
    {
       bucket = Instantiate(buckets[0],Camera.main.transform.position + new Vector3(1f,-2f,-1f),Quaternion.identity);
        bucketLocation = buckets[0].transform;
    }

    public void changeBucketPrefab()
    {
        Debug.Log("Kör changeBucketPrefab");
        if(spawnFishes.fishScore == 1)
        {
            Destroy(bucket);
            bucket = Instantiate(buckets[1], bucketLocation.position,bucketLocation.rotation);
             Debug.Log("Kör changeBucketPrefab 1");
            
            
        }

        if (spawnFishes.fishScore >= 5)
        {
            if (destroyBucket)
            {
                Destroy(bucket);
                destroyBucket = false;
                bucket = Instantiate(buckets[2], bucketLocation.position, bucketLocation.rotation);
                Debug.Log("Kör changeBucketPrefab 2");
            }
            
            
            
        }

        // fix if has voi
    }
}
