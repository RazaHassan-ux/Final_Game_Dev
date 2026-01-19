using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public bool isFromTurret;

    private void OnCollisionEnter(Collision collision)
    {
        // Hit Player
        if (isFromTurret && collision.collider.CompareTag("Player"))
        {
            Player_Health health = collision.collider.GetComponent<Player_Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
        }

        // Destroy bullet on ANY hit
        Destroy(gameObject);
    }
}
