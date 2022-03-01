using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : BaseSpawner
{
    public float minXPosition;
    public float maxXPosition;

    public override Vector2 GetRandomPosition()
    {
        return new Vector2(Random.Range(minXPosition, maxXPosition), transform.position.y);
    } 
}
