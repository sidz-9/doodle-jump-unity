using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour
{
    public GameObject platformPrefab;
    float levelWidth = 2.6f;
    float minY = 0.2f;
    float maxY = 1.5f;
    Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        spawnPosition = new Vector3();
        
    }

    // Update is called once per frame
    void Update()
    {
        StartSpawning();
    }

    void StartSpawning() {
        spawnPosition.x = Random.Range(-levelWidth, levelWidth);
        spawnPosition.y += Random.Range(minY, maxY);
        Instantiate(platformPrefab, spawnPosition, Quaternion.identity);
    }
}
