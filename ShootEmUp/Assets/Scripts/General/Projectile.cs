using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] float speed = 10;
    [SerializeField] int damage = 1;
    
    Vector2 direction = Vector2.up;
    Rigidbody2D rb;

    public Vector2 Direction { 
        get { 
            return direction; 
        } 
        set{
            direction = value;
        } 
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);    
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.gameObject.GetComponent<IDamageable>();
        if ( hit != null)
        {
            hit.TakeDamage(damage);
            // TODO: Object pooling
            Destroy(gameObject);
            return;
        }

        // If the pojectile hit anything that is not damageble, it gets destroyed. 
        Destroy(gameObject);
    }
}
