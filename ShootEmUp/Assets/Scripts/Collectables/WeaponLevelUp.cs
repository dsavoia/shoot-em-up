using UnityEngine;

public class WeaponLevelUp : BaseCollectable
{
    public override void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        
        if (playerController != null)
        {
            playerController.UpgradeWeapon();
        }

        Destroy(gameObject);
    }
}
