using UnityEngine;

public class MopBehavior : MonoBehaviour
{
    public string dirtTag = "Bubble"; // Tag to identify dirt objects
    private float cleaningTime = 3f; // Total time required to clean the dirt
    private float accumulatedCleaningTime = 0f; // Tracks accumulated cleaning time
    private GameObject currentDirt = null; // Tracks the dirt object being cleaned

    void Update()
    {
        // Check if the left mouse button is held down
        if (Input.GetMouseButton(0) && currentDirt != null)
        {
            accumulatedCleaningTime += Time.deltaTime;

            // Check if the total cleaning time is reached
            if (accumulatedCleaningTime >= cleaningTime)
            {
                //Destroy(currentDirt); // Destroy the dirt object
                currentDirt.GetComponent<SpriteRenderer>().enabled = false;
                ResetCleaning();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the "Dirt" tag
        if (other.CompareTag(dirtTag))
        {
            currentDirt = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Reset the current dirt reference if the mop exits the dirt's collision area
        if (other.gameObject == currentDirt)
        {
            currentDirt = null;
        }
    }

    private void ResetCleaning()
    {
        accumulatedCleaningTime = 0f;
        currentDirt = null;
    }
}
