using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    public bool dropItem;
    public List<GameObject> dropItemList;
    public int health;
    public float invulnerabilityTime;
    public GameObject scoreObjectPrefab;
    [Range(0, 1)]
    public float itemDropChance;
    public int scoreValue;
    public float speed;

    protected float invulnerabilityStartTime;
    protected bool isInvulnerable;
    protected Rigidbody2D rb;

    public abstract void Move();
    
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public virtual void Update()
    {
        CheckInvulnerability();
        Move();
    }

    public virtual void CheckInvulnerability()
    {
        if (!isInvulnerable) return;

        if(Time.time > invulnerabilityStartTime + invulnerabilityTime)
        {
            isInvulnerable = false;
        }
    }

    public virtual void TakeDamage(int damage) 
    {
        if (isInvulnerable) return;

        health -= damage;
        if (health <= 0) 
        {
            Die();
            return;
        }

        isInvulnerable = true;
        invulnerabilityStartTime = Time.time;
    }

    public virtual GameObject DropItem(GameObject itemPrefab, bool ignoreChance)
    {
        if (!dropItem) return null;
        if (!ignoreChance && !CheckDropItemChance()) return null;
        GameObject dropedItem = itemPrefab ? itemPrefab : GetRandomItem(); 
        return Instantiate(dropedItem, transform.position, Quaternion.identity);
    }

    public virtual bool CheckDropItemChance() 
    {
        return Random.Range(0, 1) <= itemDropChance;
    }

    public virtual GameObject GetRandomItem() 
    {        
        return dropItemList[Random.Range(0, dropItemList.Count)];
    }

    public virtual void Die()
    {
        GameObject dropedScoreItem = DropItem(scoreObjectPrefab, true);
        ScoreItem scoreItem = dropedScoreItem.GetComponent<ScoreItem>();
        scoreItem.scoreValue = scoreValue;
        Destroy(gameObject);
    }

    public virtual void OnCollisionEnter2D(Collision2D other) 
    {
        Destroy(gameObject);    
    }

}
