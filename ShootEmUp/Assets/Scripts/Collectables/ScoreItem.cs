using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreItem : BaseCollectable
{
    public int scoreValue;
    public float lookForPlayerRadius = 10;
    public LayerMask playerLayer;
    
    public override void Move() 
    {
        Vector2 newPosition = Vector2.MoveTowards(transform.position, LookForPlayer(), Time.deltaTime * speed);
        rb.MovePosition(newPosition);  
    }

    public Vector2 LookForPlayer()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, lookForPlayerRadius, playerLayer);
        
        if (hit == null) return transform.position;

        return hit.transform.position;
    }

    public override void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.AddScore(scoreValue);
        }

        Destroy(gameObject);
    }
}
