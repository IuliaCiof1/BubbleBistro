using UnityEngine;

public abstract class ICleanable:MonoBehaviour
{
    public abstract void SpawnMess();
    public abstract void CleanMess();

    private void OnEnable()
    {
        SpawnMessWave.SpawnMess += SpawnMess;
    }


    private void OnDisable()
    {
        SpawnMessWave.SpawnMess -= SpawnMess;
    }
}
