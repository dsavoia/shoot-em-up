using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    [SerializeField] protected float speed = 10;
    [SerializeField] protected int damage = 1;
    
    protected Vector2 direction = Vector2.up;
    protected Rigidbody2D rb;

    public virtual Vector2 Direction { 
        get { 
            return direction; 
        } 
        set{
            direction = value;
        } 
    }

    public virtual void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public virtual void FixedUpdate()
    {
        rb.velocity = new Vector2(direction.x * speed, direction.y * speed);    
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        IDamageable hit = other.gameObject.GetComponent<IDamageable>();
        if ( hit != null)
        {
            hit.TakeDamage(damage);
            Destroy(gameObject);
            return;
        }

        Destroy(gameObject);
    }
}
