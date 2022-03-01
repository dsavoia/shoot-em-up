using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public GunPoint[] gunPoints;

    public void Fire()
    {
        for (int i = 0; i < gunPoints.Length; i++) 
        {
            Projectile projectile = Instantiate(projectilePrefab, gunPoints[i].transform.position, Quaternion.identity).GetComponent<Projectile>();
            projectile.Direction = gunPoints[i].projectileDirection;
        }
    }
}

[System.Serializable]
public struct GunPoint 
{
    public Transform transform;
    public Vector2 projectileDirection;
}