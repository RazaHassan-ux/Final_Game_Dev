using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage_giver : MonoBehaviour
{
    float damage_amount = 10f;
    private Player_Health health;

    private void Start()
    {
        health = GetComponent<Player_Health>();

        if (health == null)
        {
            Debug.Log("No Health component found on this!");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player_Health>(out Player_Health otherhealth))
        {
            otherhealth.take_damage(damage_amount);
        }
    }

}
