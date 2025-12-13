using UnityEngine;
using UnityEngine.UI;

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
    }

    public void heal(float heal_amount)
    {
        currentHealth += heal_amount;
        if (currentHealth > 100) currentHealth = 100;
        UpdateHealthBar();
    }

    void UpdateHealthBar()
    {
        healthFill.fillAmount = currentHealth / maxHealth;
    }
}
