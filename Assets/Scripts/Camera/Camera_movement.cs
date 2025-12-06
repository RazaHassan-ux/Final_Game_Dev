using UnityEngine;

public class Camera_movement : MonoBehaviour
{
    [Header("References")]
    public Transform playerBody;   // Assign your Player (parent) here

    [Header("Mouse Settings")]
    public float sensitivityX = 300f;
    public float sensitivityY = 300f;
    public bool smoothCamera = true;
    public float smoothTime = 0.08f;

    private float xRotation = 0f;
    private Vector2 currentLook;
    private Vector2 currentLookVelocity;

    void Start()
    {
        // Hide and lock cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        Look();
    }

    void Look()
    {
        // Get raw mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * sensitivityX * Time.deltaTime;
        float mouseY = Input.GetAxisRaw("Mouse Y") * sensitivityY * Time.deltaTime;

        Vector2 targetLook = new Vector2(mouseX, mouseY);

        // Smooth movement (optional)
        if (smoothCamera)
        {
            currentLook = Vector2.SmoothDamp(currentLook, targetLook, ref currentLookVelocity, smoothTime);
        }
        else
        {
            currentLook = targetLook;
        }

        // Vertical rotation (camera only)
        xRotation -= currentLook.y;
        xRotation = Mathf.Clamp(xRotation, -85f, 85f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Horizontal rotation (player body)
        playerBody.Rotate(Vector3.up * currentLook.x);
    }
}
