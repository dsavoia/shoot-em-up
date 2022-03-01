using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialWeaponPU : BaseCollectable
{

   [SerializeField] float specialWeaponDuration = 5;

    public override void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();
        
        if (playerController != null)
        {
            playerController.ActivateSpecialWeapon(specialWeaponDuration);
            Destroy(gameObject);
        }

    }
}
