using UnityEngine;

public class MopBehavior : MonoBehaviour
{
    public string dirtTag = "Bubble"; // Tag to identify dirt objects
    private float cleaningTime = 1f; // Total time required to clean the dirt
    private float accumulatedCleaningTime = 0f; // Tracks accumulated cleaning time
    private GameObject currentDirt = null; // Tracks the dirt object being cleaned

    void Update()
    {
        if (Input.GetMouseButton(0) && currentDirt != null)
        {
            if (currentDirt.CompareTag("Bubble"))
            {
                Stats.mess--;
                Destroy(currentDirt);
                currentDirt = null;

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(dirtTag))
        {
            print("Bubbles");
            currentDirt = other.gameObject;
        }
    }
}
