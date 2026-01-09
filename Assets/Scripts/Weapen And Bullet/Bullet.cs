using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    public bool isFromTurret = false;

    void OnCollisionEnter(Collision collision)
    {
        if (isFromTurret)
        {
            Player_Health ph = collision.gameObject.GetComponent<Player_Health>();
            if (ph != null)
            {
                ph.TakeDamage(damage);
            }
        }

        Destroy(gameObject);
    }
}
