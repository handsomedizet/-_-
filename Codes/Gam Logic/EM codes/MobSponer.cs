using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSponer : MonoBehaviour
{
    public int SlimeNum = 1; 
    public int SlimeNumNow; 
    public GameObject prefabToSpawn; 
    public Vector2 spawnPosition;    
    private Transform transform; 
    // Start is called before the first frame update
    void Start()
    {
        transform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SlimeNum == 0)
        {   
            transform.position = new Vector2(Random.Range(-5f, 6f), Random.Range(-5, 6));
            SpawnPrefab(); 
            SlimeNum += 1; 
        }   
    }

    void SpawnPrefab()
    {
        if (prefabToSpawn == null)
        {
            Debug.LogError("Prefab is not assigned!");
            return;
        }

        spawnPosition = transform.position;

        GameObject spawnedPrefab = Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);
    }
}
