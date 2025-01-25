using UnityEngine;

public class BubbleGunScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletSpeed = 20f;
    public GameObject bulletHolePrefab;
    public Camera fpsCamera;
    public float maxShootDistance = 100f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, transform.position, transform.rotation);
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        bulletRb.linearVelocity = fpsCamera.transform.forward * bulletSpeed;

        RaycastHit hit;
        if (Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, maxShootDistance))
        {
            if (hit.collider != null)
            {
                ShitStain_Cleanable cleanable = hit.collider.GetComponent<ShitStain_Cleanable>();
                if (cleanable != null)
                {
                    cleanable.CleanMess();
                }
                else
                {
                    PlaceBulletHole(hit.point, hit.normal);
                }

                Destroy(bullet);
            }
        }
    }

    void PlaceBulletHole(Vector3 position, Vector3 normal)
    {
        GameObject bulletHole = Instantiate(bulletHolePrefab, position, Quaternion.LookRotation(normal));

        Destroy(bulletHole, 5f);
    }
}
