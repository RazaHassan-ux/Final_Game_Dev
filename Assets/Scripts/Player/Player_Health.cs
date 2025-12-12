using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Health : MonoBehaviour
{
    float max_health = 100f;
    float current_health;
    public TextMeshProUGUI healthText;
    public GameObject canvas;
    bool is_dead => current_health <= 0f;

    event System.Action on_death;


    private void Start()
    {
        current_health = max_health;
        canvas.SetActive(true);
    }

    private void Update()
    {
        UpdateHealthUI();
    }

    public void take_damage(float take_damage)
    {
        current_health -= take_damage;
        if (current_health < 0f) current_health = 0f;

        if (is_dead)
        {
            on_death?.Invoke();
            StartCoroutine(Die(3f));
        }

    }

    public void heal(float heal_amount)
    {
        current_health += heal_amount;
        if (current_health > max_health) current_health = max_health;
    }

    private IEnumerator Die(float seconds)
    {
        Debug.Log("Player Died! Wait 3 seconds game will Load Automatically!");
        gameObject.SetActive(false);

        yield return new WaitForSecondsRealtime(seconds);

        SceneManager.LoadScene(0);
    }
    private void UpdateHealthUI()
    {
        if (healthText != null)
        {
            healthText.text = "Health: " + current_health.ToString();
        }
    }
}
