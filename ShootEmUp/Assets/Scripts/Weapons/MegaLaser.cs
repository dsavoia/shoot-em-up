using System.Collections;
using UnityEngine;

public class MegaLaser : MonoBehaviour
{
    [SerializeField] int damage = 2;
    [SerializeField] float duration = 6;
    
    // Avoiding calling it every frame
    [SerializeField] float hitCoolDown = 0.1f;
    float lastHitTime;

    void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time > lastHitTime + hitCoolDown) 
        {
            lastHitTime = Time.time;
            IDamageable hit = other.gameObject.GetComponent<IDamageable>();
            if ( hit != null)
            {
                hit.TakeDamage(damage);
            }
        }
    }
}
