using System.Collections;
using UnityEngine;

public class Weapen : MonoBehaviour
{
    public GameObject bulletPrefab;        // Bullet prefab
    public Transform bulletSpawn;          // Where bullet spawns from
    public float bulletVelocity = 30f;     // Bullet speed
    public float bulletLifeTime = 3f;      // Bullet destroy time

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            FireWeapon();
        }
    }

    void FireWeapon()
    {
        // Create bullet
        GameObject bullet = Instantiate(
            bulletPrefab,
            bulletSpawn.position,
            bulletSpawn.rotation
        );

        // Add force to bullet
        Rigidbody rb = bullet.GetComponent<Rigidbody>();
        rb.AddForce(bulletSpawn.forward.normalized * bulletVelocity, ForceMode.Impulse);

        // Destroy bullet after time
        StartCoroutine(DestroyBulletAfterTime(bullet, bulletLifeTime));
    }

    IEnumerator DestroyBulletAfterTime(GameObject bullet, float delay)
    {
        yield return new WaitForSeconds(delay);
        Destroy(bullet);
    }
}
