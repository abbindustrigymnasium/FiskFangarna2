using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class SpawnInfoSign : MonoBehaviour
{
    [SerializeField] List<GameObject> fishSign = new List<GameObject>();
    private bool hasSpawned = false;
    GameObject sign;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnSign", 1f);
    }

    // Update is called once per frame
    

    void Update()
    {
        
            
 
    }

    void SpawnSign()
    {
        sign = Instantiate(fishSign[0], Camera.main.transform.position + new Vector3(5f,-2f,5f), Quaternion.identity);
        sign.transform.Rotate(0f,90f,0);
        Debug.Log("Sign " + sign.transform.position);
        hasSpawned = true;
    }
}
