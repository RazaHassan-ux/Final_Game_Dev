using UnityEngine;

public class Sliding_door_script : MonoBehaviour
{
    [Header("Door Parts")]
    public Transform leftDoor;
    public Transform rightDoor;

    [Header("Positions")]
    public Vector3 leftClosedPos;
    public Vector3 leftOpenPos;

    public Vector3 rightClosedPos;
    public Vector3 rightOpenPos;

    [Header("Settings")]
    public float speed = 3f;

    [HideInInspector]
    public bool open = false;  // controlled by machine

    private void Update()
    {
        if (open)
        {
            leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftOpenPos, Time.deltaTime * speed);
            rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightOpenPos, Time.deltaTime * speed);
        }
        else
        {
            leftDoor.localPosition = Vector3.Lerp(leftDoor.localPosition, leftClosedPos, Time.deltaTime * speed);
            rightDoor.localPosition = Vector3.Lerp(rightDoor.localPosition, rightClosedPos, Time.deltaTime * speed);
        }
    }
}
