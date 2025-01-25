using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bulletPrefab;        // Bullet prefab
    public float bulletSpeed = 20f;        // Speed of the bullet
    public GameObject bulletHolePrefab;    // Bullet hole 3D object prefab
    public Camera fpsCamera;              // Reference to the camera
    public float maxShootDistance = 100f;  // Max distance the bullet can travel

    void Update()
    {
        // Detect left mouse button press for shooting
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Create bullet and set direction
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.linearVelocity = fpsCamera.transform.forward * bulletSpeed;

        // Raycast to detect collision
        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, maxShootDistance))
        {
            // Check if the bullet hits an object
            if (hit.collider != null)
            {
                // Place a bullet hole at the hit point
                PlaceBulletHole(hit.point, hit.normal);

                // Destroy the bullet (it will disappear once it collides)
                Destroy(bullet);
            }
        }
    }

    void PlaceBulletHole(Vector3 position, Vector3 normal)
    {
        // Instantiate the bullet hole prefab at the point of collision
        GameObject bulletHole = Instantiate(bulletHolePrefab, position, Quaternion.LookRotation(normal));

        // Optionally, set a lifespan for the bullet hole, or leave it there
        Destroy(bulletHole, 5f);  // Bullet hole will disappear after 5 seconds
    }
}
