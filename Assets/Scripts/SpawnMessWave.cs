using System;
using UnityEngine;
using System.Collections;

public class SpawnMessWave : MonoBehaviour
{
    public static event Action SpawnMess;
    [SerializeField] private float waveInterval;
    [SerializeField] private float intervalDecreaseRate;
    [SerializeField] private float minWaveInterval;
    [SerializeField] private float currentWaveInterval;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        currentWaveInterval = waveInterval;
        InvokeRepeating(nameof(SpawnWave), 4, waveInterval);
    }



    void SpawnWave()
    {
        currentWaveInterval = Mathf.Max(currentWaveInterval - intervalDecreaseRate, minWaveInterval);
        SpawnMess?.Invoke();
        

    }
        
}
