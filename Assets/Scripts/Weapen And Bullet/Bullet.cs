using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;        // bullet damage
    public bool isFromTurret = false; // true = turret bullet, false = player bullet

    void OnCollisionEnter(Collision collision)
    {
        // If bullet is from turret, damage the player
        if (isFromTurret && collision.gameObject.CompareTag("Player"))
        {
            Player_Health playerHealth = collision.gameObject.GetComponent<Player_Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
            }
        }
        // If bullet is from player, damage the turret
        else if (!isFromTurret && collision.gameObject.CompareTag("Enemy"))
        {
            Turret turret = collision.gameObject.GetComponent<Turret>();
            if (turret != null)
            {
                turret.TakeDamage(damage);
            }
        }

        Destroy(gameObject); // destroy bullet after hit
    }
}
