using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : BaseSpawner
{
    public float minYPosition;
    public float maxYPosition;
    public float leftSpawnPosition;
    public float rightSpawnPosition;

    public override Vector2 GetRandomPosition()
    {
        float xSpawnPosition = Random.value <= 0.5 ? leftSpawnPosition : rightSpawnPosition;
        return new Vector2(xSpawnPosition, Random.Range(minYPosition, maxYPosition));
    }
}
