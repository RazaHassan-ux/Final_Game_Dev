using UnityEngine;

public class PlayerRaycastPickup : MonoBehaviour
{
    public float pickupDistance = 3f;
    public Camera playerCam; // drag your main camera
    public LayerMask interactLayer; // layer for interactables

    private Player_Inventory inv;

    void Start()
    {
        inv = GetComponent<Player_Inventory>();
    }

    void Update()
    {
        Ray ray = new Ray(playerCam.transform.position, playerCam.transform.forward);
        RaycastHit hit;

        // Raycast forward
        if (Physics.Raycast(ray, out hit, pickupDistance, interactLayer))
        {
            // If we look at a keycard
            if (hit.collider.CompareTag("Selectable"))
            {
                // Press E to pick up
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inv.hasKeycard = true;
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Keycard picked via Raycast!");
                }
            }
        }
    }
}
