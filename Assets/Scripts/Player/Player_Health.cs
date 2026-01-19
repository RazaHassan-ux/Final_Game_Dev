using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Needed for scene loading

public class Player_Health : MonoBehaviour
{
    public float maxHealth = 100f;
    private float currentHealth;

    public Image healthFill;

    void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthBar();
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth < 0)
            currentHealth = 0;

        UpdateHealthBar();
        Die(); // Check if player should die
    }

    public void heal(float heal_amount)
    {
        currentHealth += heal_amount;
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthFill.fillAmount = currentHealth / maxHealth;
    }

    void Die()
    {
        if (currentHealth <= 0)
        {
            // Load Scene 3
            SceneManager.LoadScene(3);
        }
    }
}
