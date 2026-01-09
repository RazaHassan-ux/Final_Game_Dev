using UnityEngine;
using UnityEngine.UI;

public class EnemyHealthBar : MonoBehaviour
{
    public Image fillImage;
    public Transform target;     // Turret base or head
    public Transform player;     // Player transform
    public Vector3 offset = new Vector3(0, 2f, 0);

    private float maxHealth;

    void LateUpdate()
    {
        if (!target || !player) return;

        // Follow turret
        transform.position = target.position + offset;

        // Rotate ONLY on Y axis toward player (same as turret head)
        Vector3 dir = player.position - transform.position;
        dir.y = 0f;

        if (dir != Vector3.zero)
            transform.rotation = Quaternion.LookRotation(dir);
    }

    public void SetMaxHealth(float value)
    {
        maxHealth = value;
        fillImage.fillAmount = 1f;
    }

    public void UpdateHealth(float currentHealth)
    {
        fillImage.fillAmount = currentHealth / maxHealth;
    }
}
