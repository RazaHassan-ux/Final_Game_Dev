using UnityEngine;

public class AutoDrawer : MonoBehaviour
{
    public Transform drawer;            // The sliding part
    public float slideAmount = 0.4f;    // How far it slides out
    public float speed = 5f;
    public float openRadius = 3f;       // Distance to auto-open
    public Transform player;

    private Vector3 closedPos;
    private Vector3 openPos;
    private bool isOpen;

    void Start()
    {
        // Record closed position
        closedPos = drawer.localPosition;

        // Calculate open position automatically
        openPos = closedPos + new Vector3(0, 0, slideAmount);
    }

    void Update()
    {
        if (player == null) return;

        float dist = Vector3.Distance(transform.position, player.position);

        // Opening condition:
        isOpen = dist <= openRadius;

        // Smooth slide
        if (isOpen)
        {
            drawer.localPosition = Vector3.Lerp(drawer.localPosition, openPos, Time.deltaTime * speed);
        }
        else
        {
            drawer.localPosition = Vector3.Lerp(drawer.localPosition, closedPos, Time.deltaTime * speed);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, openRadius);
    }
}
