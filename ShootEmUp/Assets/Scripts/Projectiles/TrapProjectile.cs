using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapProjectile : BaseProjectile
{
    public float lookForPlayerRadius;
    public LayerMask playerLayer;
    public float duration;

    Vector3 targetPosition;
    float durationTimerStart;

    public override void Start()
    {
        base.Start();
        targetPosition = LookForPlayer();
    }

    public Vector3 LookForPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, lookForPlayerRadius, playerLayer);
        
        if (hit == null) return transform.position;

        return hit.transform.position;
    }

    public override void FixedUpdate(){}

    void Update()
    {
        if (transform.position != targetPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);    
            durationTimerStart = Time.time;
        }

        if(Time.time > durationTimerStart + duration)
        {
            Destroy(gameObject);
        }
    }
}
