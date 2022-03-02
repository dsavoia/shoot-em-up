using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseEnemy : MonoBehaviour, IDamageable
{
    public Weapon[] weapons;
    public List<GameObject> itemList;
    public int health;
    public GameObject scoreObjectPrefab;
    [Range(0, 1)]
    public float itemDropChance;
    public int scoreValue;

    public abstract void TakeDamage(int damage);
    public abstract void Move();

    public virtual GameObject DropItem(GameObject itemPrefab, bool ignoreChance)
    {
        if (!ignoreChance && !ShouldDropItem()) return null;
        GameObject dropItem = itemPrefab ? itemPrefab : GetRandomItem(); 
        return Instantiate(dropItem, transform.position, Quaternion.identity);
    }

    public virtual bool ShouldDropItem() 
    {
        return Random.Range(0, 1) <= itemDropChance;
    }

    public virtual GameObject GetRandomItem() 
    {        
        return itemList[Random.Range(0, itemList.Count)];
    }

    public virtual void Die()
    {
        GameObject dropedScore = DropItem(scoreObjectPrefab, true);
        ScoreItem scoreItem = dropedScore.GetComponent<ScoreItem>();
        scoreItem.scoreValue = scoreValue;
        Destroy(gameObject);
    }
}
