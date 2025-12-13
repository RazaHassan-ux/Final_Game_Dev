using UnityEngine;

public class Damage_Reciever : MonoBehaviour
{
    public float damageAmount = 10f;
    public float damageInterval = 1f;

    private float nextDamageTime;

    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (Time.time < nextDamageTime)
            return;

        if (hit.gameObject.CompareTag("Player"))
        {
            Player_Health health = hit.gameObject.GetComponent<Player_Health>();
            if (health != null)
            {
                health.TakeDamage(damageAmount);
                nextDamageTime = Time.time + damageInterval;
            }
        }
    }
}
