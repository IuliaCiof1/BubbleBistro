using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject bubblePrefab;
    public float bubbleSpeed = 20f;
    public GameObject placedBubblePrefab;
    public Camera fpsCamera;
    public float maxShootDistance = 20f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ShootBubbles();
        }
    }

    void ShootBubbles()
    {
        GameObject bubble = Instantiate(bubblePrefab, transform.position, transform.rotation);
        Rigidbody bubbleRB = bubble.GetComponent<Rigidbody>();
        bubbleRB.linearVelocity = fpsCamera.transform.forward * bubbleSpeed;

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
                    PlaceBubbles(hit.point, hit.normal);
                }

                Destroy(bubble);
            }
        }
    }

    void PlaceBubbles(Vector3 position, Vector3 normal)
    {
        GameObject bulletHole = Instantiate(placedBubblePrefab, position, Quaternion.LookRotation(normal));

        Destroy(bulletHole, 5f);
    }
}
