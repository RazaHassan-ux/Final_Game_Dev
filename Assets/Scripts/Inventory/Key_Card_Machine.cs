using UnityEngine;

public class Key_Card_Machine : MonoBehaviour
{
    public float interactDistance = 3f;
    public Camera cam; // drag your player camera
    public LayerMask interactLayer; // layer for machines

    private Player_Inventory inv;

    private void Start()
    {
        inv = GetComponent<Player_Inventory>();
    }

    private void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactDistance, interactLayer))
        {
            // If we are looking at the machine
            if (hit.collider.CompareTag("KeyCardMachine"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Sliding_door_script door = hit.collider.GetComponent<KeycardMachineReference>().door;

                    if (inv.hasKeycard)
                    {
                        door.open = true;
                        inv.hasKeycard = false;
                        Debug.Log("Door unlocked (Raycast Machine)!");
                    }
                    else
                    {
                        Debug.Log("You need a keycard!");
                    }
                }
            }
        }
    }
}
