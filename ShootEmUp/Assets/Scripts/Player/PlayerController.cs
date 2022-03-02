using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour, IDamageable
{

    [SerializeField] float speed = 3;
    [SerializeField] Weapon[] weapons;
    [SerializeField] GameObject specialWeapon;
    [SerializeField] Transform playerSpawnPoint;

    Rigidbody2D rb;
    PlayerInput playerInput;
    Weapon currentWeapon;

    int lives = 3;

    int weaponLevel = 0;
    int maxWeaponLevel;

    bool isInvencible;
    float invencibilityStartTime;
    float invencibilityTimer;

    bool isUsingSpecialWeapon;
    float specialWeaponStartTime;
    float specialWeaponTimer;

    public int playerScore;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerInput = GetComponent<PlayerInput>();

        maxWeaponLevel = weapons.Length - 1;
        weaponLevel = 0;
        SwitchWeapon(weaponLevel);
        specialWeapon.SetActive(false);
        playerScore = 0;
    }
    
    void Update()
    {
        CheckInvencibility();
        CheckSpecialWeaponPowerUp();
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(playerInput.moveDirection.x * speed, playerInput.moveDirection.y * speed);
    }

    public void Shoot() 
    {
        if (isUsingSpecialWeapon) return;
        
        currentWeapon.Fire();
    }

    public void SwitchWeapon(int weaponIndex) 
    {
        currentWeapon = weapons[weaponIndex].GetComponent<Weapon>();
    }

    public void UpgradeWeapon() 
    {
        if (weaponLevel < maxWeaponLevel) 
        {
            weaponLevel++;
            currentWeapon = weapons[weaponLevel].GetComponent<Weapon>();
        }
    }

    public void ActivateInvencibility(float duration)
    {
        invencibilityStartTime = Time.time;
        invencibilityTimer = duration;
        isInvencible = true;
    }

    public void ActivateSpecialWeapon(float duration)
    {
        specialWeapon.SetActive(true);
        specialWeaponStartTime = Time.time;
        specialWeaponTimer = duration;
        isUsingSpecialWeapon = true;
    }

    // Check if the player should still be invencible
    void CheckInvencibility()
    {
        if (!isInvencible) return;

        if (Time.time > invencibilityStartTime + invencibilityTimer)
        {
            isInvencible = false;
        } 
    }

    // Check if the special weapon should still be in use
    void CheckSpecialWeaponPowerUp()
    {
        if (!isUsingSpecialWeapon) return;

        if (Time.time > specialWeaponStartTime + specialWeaponTimer)
        {
            isUsingSpecialWeapon = false;
            specialWeapon.SetActive(false);
        } 
    }

    public void AddScore(int score) 
    {
        playerScore += score;
        Debug.Log("Player Score: " + playerScore);
    }

    public void TakeDamage(int damage) 
    {
        if (isInvencible) return;

        Die();
    }

    public void Die() 
    {
        if (lives > 0) 
        {
            lives --;
            transform.position = playerSpawnPoint.position;
            return;
        }

        Destroy(gameObject);
    }
}
