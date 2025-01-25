using System;
using UnityEngine;
using System.Collections;

public class SpawnMessWave : MonoBehaviour
{
    public static event Action SpawnMess;
    [SerializeField] private float waveInterval;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        InvokeRepeating(nameof(SpawnWave), 4, waveInterval);
    }



    void SpawnWave()
    {
        SpawnMess?.Invoke();
        

    }
        
}
