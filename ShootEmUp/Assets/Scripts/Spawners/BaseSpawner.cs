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
    public bool ignoreSpawnChance;

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

    public virtual GameObject SpawnObject(GameObject spawnObject) 
    {
        if (Time.time > lastSpawnedTime + nextSpawnTimer)
        {
            lastSpawnedTime = Time.time;
            nextSpawnTimer = Random.Range(minSpawnIterval, maxSpawnIterval);
            if (!ShouldSpawnObject()) return null;

            Vector2 position = GetRandomPosition();
            GameObject objToSpawn = spawnObject ? spawnObject : GetRandomObject();
            return Instantiate(objToSpawn, position, Quaternion.identity);
        }

        return null;
    }

    public virtual bool ShouldSpawnObject() 
    {
        if (ignoreSpawnChance) return true;
        return Random.Range(0, 1) <= spawnChance;
    }

    public virtual GameObject GetRandomObject() 
    {        
        return objectList[Random.Range(0, objectList.Count)];
    }

    public abstract Vector2 GetRandomPosition(); 
}
