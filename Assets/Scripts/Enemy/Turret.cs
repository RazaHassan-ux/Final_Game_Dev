using UnityEngine;
using UnityEngine.UI;

public class Turret : MonoBehaviour
{
    [Header("References")]
    public Transform firePoint;
    public GameObject bulletPrefab;
    public Transform player;

    [Header("Rotation")]
    public float rotationSpeed = 5f;
    public float rotationOffset = 180f;

    [Header("Shooting")]
    public float fireRate = 0.1f; // 10 bullets/sec
    public float bulletSpeed = 25f;
    public float detectionRange = 20f;
    public float bulletDamage = 10f;

    [Header("Turret Stats")]
    public float maxHealth = 100f;
    private float currentHealth;

    [Header("Health Bar")]
    public EnemyHealthBar healthBar; // Reference to your floating health bar

    private float fireTimer;

    void Start()
    {
        currentHealth = maxHealth;

        // Initialize the health bar
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxHealth);
            healthBar.UpdateHealth(currentHealth);
        }
        else
        {
            Debug.LogError("HealthBar not assigned on " + gameObject.name);
        }
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);
        if (distance > detectionRange) return;

        // Rotate turret toward player (head style)
        Vector3 direction = player.position - transform.position;
        direction.y = 0f;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        lookRotation *= Quaternion.Euler(0f, rotationOffset, 0f);

        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, rotationSpeed * Time.deltaTime);

        // Shoot bullets
        fireTimer += Time.deltaTime;
        while (fireTimer >= fireRate)
        {
            Shoot();
            fireTimer -= fireRate;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        if (rb != null)
            rb.linearVelocity = firePoint.forward * bulletSpeed;

        Bullet bulletScript = bullet.GetComponent<Bullet>();
        if (bulletScript != null)
        {
            bulletScript.damage = bulletDamage;
            bulletScript.isFromTurret = true;
        }

        Destroy(bullet, 5f);
    }

    // Called by bullets or damage sources
    public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        if (healthBar != null)
            healthBar.UpdateHealth(currentHealth);

        if (currentHealth <= 0)
            Die();
    }

    void Die()
    {
        // Optional: add explosion effect here
        Destroy(gameObject);
    }

    public void ChangeHealth(float amount)
    {
        if (amount < 0)
            TakeDamage(-amount);
    }
}
