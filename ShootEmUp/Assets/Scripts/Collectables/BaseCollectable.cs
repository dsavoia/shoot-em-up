using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseCollectable : MonoBehaviour, ICollectable
{
    public float minSpeed = 1f;
    public float maxSpeed = 4f;
    public float minXDirection = -0.6f;
    public float maxXDirection = 0.6f;

    protected Rigidbody2D rb;
    protected float speed;
    protected Vector2 direction;

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void OnEnable() 
    {
        speed = GetRandomSpeed();
        direction = GetRandomDirection();
    }

    public virtual void FixedUpdate()
    {
        Move();
    }

    public virtual void Move() 
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);  
    }

    public virtual float GetRandomSpeed()
    {
        return Random.Range(minSpeed, maxSpeed);
    }

    // Will only have a random X direction. Items will always move down (Y == -1).
    public virtual Vector2 GetRandomDirection()
    {
        return new Vector2(Random.Range(minXDirection, maxXDirection), -1);
    }

    public abstract void OnTriggerEnter2D(Collider2D other);
}
