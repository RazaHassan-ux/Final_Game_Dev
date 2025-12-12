using Ilumisoft.HealthSystem;
using UnityEngine;

public class Damage_giver : MonoBehaviour
{
    public float damageAmount = 10f;

    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has a Health component
        if (collision.gameObject.TryGetComponent<Health>(out Health health))
        {
            health.ApplyDamage(damageAmount);
            Debug.Log("Collision detected");
        }
    }
}
