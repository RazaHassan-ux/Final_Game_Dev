using UnityEngine;

public class Key_Card_Machine : MonoBehaviour
{
    public Sliding_door_script door; // drag your door here in inspector

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player_Inventory inv = other.GetComponent<Player_Inventory>();

                if (inv.hasKeycard)
                {
                    // Unlock the door
                    door.open = true;

                    // Optional: remove card after use
                    inv.hasKeycard = false;

                    Debug.Log("Door unlocked!");
                }
                else
                {
                    Debug.Log("You need a keycard!");
                }
            }
        }
    }
}
