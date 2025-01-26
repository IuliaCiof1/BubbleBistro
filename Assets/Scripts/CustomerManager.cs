using System.Collections.Generic;
using UnityEngine;

public class CustomerManager : MonoBehaviour
{
    public static List<GameObject> chairs = new List<GameObject>();
    [SerializeField] GameObject customerSet;

    private void OnEnable()
    {
        SpawnMessWave.SpawnMess += SpawnCustomers;
    }


    private void OnDisable()
    {
        SpawnMessWave.SpawnMess -= SpawnCustomers;
    }

    private void Start()
    {
        // Find all objects with "chair" in their name
        GameObject[] allObjects = FindObjectsByType<GameObject>(FindObjectsSortMode.None); // Get all active GameObjects in the scene

        foreach (GameObject obj in allObjects)
        {
            if (obj.name.ToLower().Contains("chair")) // Check if the name contains "chair" (case-insensitive)
            {
                chairs.Add(obj); // Add to the list
                
            }
        }
       
    }

    void SpawnCustomers()
    {
        Instantiate(customerSet, transform);
    }
}
