using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseSpawner : MonoBehaviour
{

    public List<GameObject> objectList;
    public float minSpawnIterval;
    public float maxSpawnIterval;
    public float waitBeforeSartSpawning = 5;
    [Range(0, 1)]
    public float spawnChance;

    protected float lastSpawnedTime;
    protected float nextSpawnTimer;

    public virtual void Start()
    {
        lastSpawnedTime = Time.time + waitBeforeSartSpawning;
        nextSpawnTimer = waitBeforeSartSpawning;
    }

    public virtual void Update() 
    {
        SpawnObject(null);
    }

    public virtual void SpawnObject(GameObject spawnObject) 
    {
        if (Time.time > lastSpawnedTime + nextSpawnTimer)
        {
            lastSpawnedTime = Time.time;
            nextSpawnTimer = Time.time + Random.Range(minSpawnIterval, maxSpawnIterval);
            
            if (!ShouldSpawnObject()) return;

            Vector2 position = GetRandomPosition();
            GameObject objToSpawn = spawnObject ? spawnObject : GetRandomObject();
            Instantiate(objToSpawn, position, Quaternion.identity);
        }

        return;
    }

    public virtual bool ShouldSpawnObject() 
    {
        return Random.Range(0, 1) <= spawnChance;
    }

    public virtual GameObject GetRandomObject() 
    {        
        return objectList[Random.Range(0, objectList.Count)];
    }

    public abstract Vector2 GetRandomPosition(); 
}
