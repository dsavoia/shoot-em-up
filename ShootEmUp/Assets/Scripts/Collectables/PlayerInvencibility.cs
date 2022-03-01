using System.Collections;
using UnityEngine;

public class PlayerInvencibility : BaseCollectable
{

    [SerializeField] float invencibilityDuration = 5;

    public override void OnTriggerEnter2D(Collider2D other) 
    {
        PlayerController playerController = other.gameObject.GetComponent<PlayerController>();

        if (playerController != null)
        {
            playerController.StartInvencibility(invencibilityDuration);
            Destroy(gameObject);
        }

    }
}
