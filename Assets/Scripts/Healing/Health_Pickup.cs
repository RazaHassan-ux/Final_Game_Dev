using UnityEngine;

public class HeartPickup : MonoBehaviour
{
    public float healAmount = 20f; // How much this heart heals

    private void OnTriggerEnter(Collider other)
    {
        // Check if the object that touched the heart has the Player_Health component
        Player_Health playerHealth = other.GetComponent<Player_Health>();
        if (playerHealth != null)
        {
            // Heal the player
            playerHealth.heal(healAmount);

            // Destroy the heart prefab
            Destroy(gameObject);
        }
    }
}
