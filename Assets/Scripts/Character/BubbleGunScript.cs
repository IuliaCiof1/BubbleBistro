using UnityEngine;

public class BubbleGun : MonoBehaviour
{
    public GameObject bubblePrefab;  // Reference to the bubble prefab
    public float bubbleRadius = 1.5f; // Radius within which we will check for existing bubbles
    public float placementDelay = 0.1f;  // Delay to avoid continuous bubble placement

    private bool canPlaceBubble = true;

    void Update()
    {
        if (Input.GetMouseButton(0) && canPlaceBubble)  // Left Mouse Button (0)
        {
            canPlaceBubble = false; // Disable placement for a short period (debounce)

            // Raycast from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                Vector3 hitPoint = hit.point;
                if (!IsBubbleAtPosition(hitPoint))
                {
                    // Create the bubble at the hit position
                    Quaternion rotation = Quaternion.FromToRotation(Vector3.up, hit.normal);
                    Instantiate(bubblePrefab, hitPoint, rotation);
                    Stats.mess++;
                }
            }

            // Allow bubble placement after the delay
            Invoke("ResetPlacement", placementDelay);
        }
    }

    // Function to check if there's a bubble already placed at the position
    bool IsBubbleAtPosition(Vector3 position)
    {
        // Find all the bubbles in the scene
        GameObject[] bubbles = GameObject.FindGameObjectsWithTag("Bubble");

        foreach (GameObject bubble in bubbles)
        {
            // Check the distance between the position and each bubble
            if (Vector3.Distance(bubble.transform.position, position) < bubbleRadius)
            {
                return true; // A bubble is already placed near the position
            }
        }

        return false; // No bubble found at the position
    }

    // Reset placement flag after the delay
    void ResetPlacement()
    {
        canPlaceBubble = true;
    }
}
