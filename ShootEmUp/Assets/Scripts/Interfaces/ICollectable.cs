using UnityEngine;

public interface ICollectable
{
    public void OnTriggerEnter2D(Collider2D other);
}
