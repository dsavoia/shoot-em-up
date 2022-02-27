using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    [SerializeField] float speed = 3;

    Rigidbody2D rb;
    PlayerInputActions playerControls;
    Vector2 moveDirection = Vector2.zero;
    InputAction move;
    InputAction fire;

    void Awake() 
    {
        playerControls = new PlayerInputActions();
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

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }
    
    void Update()
    {
        moveDirection = move.ReadValue<Vector2>();
    }

    // TODO: Move out to a separate move script if movement gets more complex
    void FixedUpdate()
    {
        rb.velocity = new Vector2(moveDirection.x * speed, moveDirection.y * speed);
    }

    void Fire(InputAction.CallbackContext context) 
    {
        Debug.Log("Fired");
    }
}
