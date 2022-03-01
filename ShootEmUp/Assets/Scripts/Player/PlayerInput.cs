using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{

    PlayerInputActions playerControls;
    InputAction move;
    InputAction fire;
    PlayerController playerController;

    public Vector2 moveDirection = Vector2.zero;

    void Awake() 
    {
        playerControls = new PlayerInputActions();
        playerController = GetComponent<PlayerController>();
    }

    void OnEnable() 
    {
        move = playerControls.Player.Move;
        move.Enable();

        fire = playerControls.Player.Fire;
        fire.Enable();
        fire.performed += Fire;
    }

    void OnDisable() 
    {
        move.Disable();
        fire.Disable();
    }

    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    void Fire(InputAction.CallbackContext context) 
    {
        playerController.Shoot();
    }
}
