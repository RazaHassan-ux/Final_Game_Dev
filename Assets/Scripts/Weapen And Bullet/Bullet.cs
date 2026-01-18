using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 25f;
    public float damage = 10f;
    public bool isFromTurret;

    private Vector3 lastPosition;

    void Start()
    {
        lastPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;
        Vector3 direction = currentPosition - lastPosition;
        float distance = direction.magnitude;

        if (distance > 0f)
        {
            RaycastHit hit;
            if (Physics.Raycast(lastPosition, direction.normalized, out hit, distance))
            {
                HandleHit(hit);
                return;
            }
        }

        lastPosition = currentPosition;
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void HandleHit(RaycastHit hit)
    {
        // Player hit
        if (hit.collider.CompareTag("Player") && isFromTurret)
        {
            hit.collider.GetComponent<Player_Health>()?.TakeDamage(damage);
        }

        // Wall / anything else
        Destroy(gameObject);
    }
}
