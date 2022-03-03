using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemy : BaseEnemy
{
    public Weapon weapon;
    public float shootCooldown;
    float lastShoot;

    float xMovementDirection;

    private void OnEnable() 
    {
        xMovementDirection = Mathf.Sign(transform.position.x);
        lastShoot = Time.time + shootCooldown/2;  
    }

    public override void Update()
    {
        base.Update();
        Shoot();
    }

    public override void Move()
    {
        rb.velocity = new Vector2(-xMovementDirection * speed, 0);
    }

    void Shoot()
    {
        if (Time.time > lastShoot + shootCooldown)
        {
            lastShoot = Time.time;
            weapon.Fire();
        }
    }
}
