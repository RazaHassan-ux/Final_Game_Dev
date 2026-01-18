using UnityEngine;

public class Sliding_door_with_radius : MonoBehaviour
{
    [Header("Door Parts")]
    public Transform leftDoor;
    public Transform rightDoor;

    [Header("Open Offsets (Local)")]
    public Vector3 leftOpenOffset = new Vector3(-1.5f, 0, 0);
    public Vector3 rightOpenOffset = new Vector3(1.5f, 0, 0);

    [Header("Settings")]
    public float speed = 3f;
    public float openRadius = 5f;

    [Header("Player")]
    public Transform player;

    private Vector3 leftClosedPos;
    private Vector3 rightClosedPos;
    private Vector3 leftOpenPos;
    private Vector3 rightOpenPos;

    private bool isUnlocked = true; // SET TRUE FOR TESTING

    void Start()
    {
        leftClosedPos = leftDoor.localPosition;
        rightClosedPos = rightDoor.localPosition;

        leftOpenPos = leftClosedPos + leftOpenOffset;
        rightOpenPos = rightClosedPos + rightOpenOffset;
    }

    void Update()
    {
        if (!isUnlocked || player == null)
            return;

        float dist = Vector3.Distance(transform.position, player.position);
        bool open = dist <= openRadius;

        if (open)
        {
            leftDoor.localPosition = Vector3.MoveTowards(
                leftDoor.localPosition, leftOpenPos, speed * Time.deltaTime);

            rightDoor.localPosition = Vector3.MoveTowards(
                rightDoor.localPosition, rightOpenPos, speed * Time.deltaTime);
        }
        else
        {
            leftDoor.localPosition = Vector3.MoveTowards(
                leftDoor.localPosition, leftClosedPos, speed * Time.deltaTime);

            rightDoor.localPosition = Vector3.MoveTowards(
                rightDoor.localPosition, rightClosedPos, speed * Time.deltaTime);
        }
    }

    public void UnlockDoor()
    {
        isUnlocked = true;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, openRadius);
    }
}
