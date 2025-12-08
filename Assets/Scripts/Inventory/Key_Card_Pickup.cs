using UnityEngine;

public class Key_Card_Pickup : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                other.GetComponent<Player_Inventory>().hasKeycard = true;
                Destroy(gameObject); // remove keycard
                Debug.Log("Picked Keycard");
            }
        }
    }
}
