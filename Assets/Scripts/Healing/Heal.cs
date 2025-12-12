using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : MonoBehaviour
{
    float heal_amount = 50f;
    private Player_Health Heal_new;

    private void Start()
    {
        Heal_new = GetComponent<Player_Health>();
        if (Heal_new == null)
        {
            Debug.Log("No Health component found on this object!");

        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player_Health>(out Player_Health otherhealth))
        {
            otherhealth.heal(heal_amount);
            gameObject.SetActive(false);
        }
    }
}
