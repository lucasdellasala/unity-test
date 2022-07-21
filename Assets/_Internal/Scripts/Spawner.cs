using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public int amountOfSpawns;
    public float distanceBetweenSpawns = 1f;
    public float distanceUpBetweenSpawns = 1f;

    void Start()
    {
        Spawn();
    }

    private void Spawn()
    {
        for(int i=0; i<amountOfSpawns; i++)
        {
            Vector3 spawnPos = transform.position;
            spawnPos += transform.forward * distanceBetweenSpawns * i; // Forward pos
            spawnPos += transform.up * distanceUpBetweenSpawns * i; // Up pos
            GameObject obj = Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
            obj.GetComponent<ColorChanger>().SetColor(i);
        }
    }
}
