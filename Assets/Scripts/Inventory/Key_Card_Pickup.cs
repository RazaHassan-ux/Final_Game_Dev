using UnityEngine;

public class Key_Card_Pickup : MonoBehaviour
{
    public float pickupDistance = 3f;
    public Camera cam; // drag your player camera
    public LayerMask interactLayer; // set to Interactable layer

    private Player_Inventory inv;

    private void Start()
    {
        inv = GetComponent<Player_Inventory>();
    }

    private void Update()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, pickupDistance, interactLayer))
        {
            if (hit.collider.CompareTag("Selectable"))
            {
                if (Input.GetKeyDown(KeyCode.E))
                {
                    inv.hasKeycard = true;
                    Destroy(hit.collider.gameObject);
                    Debug.Log("Picked Keycard (Raycast)");
                }
            }
        }
    }
}
