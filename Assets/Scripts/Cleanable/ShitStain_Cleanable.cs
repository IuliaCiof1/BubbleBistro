using UnityEngine;

public class ShitStain_Cleanable : ICleanable
{
    public Material cleanMaterial; // The material to apply when cleaned
    private Material originalMaterial;

    public override void CleanMess()
    {
        GetComponent<Renderer>().material = cleanMaterial;
    }

    public override void SpawnMess()
    {
        int randomSpawn = Random.Range(0, 6);
        if (randomSpawn == 1)
        {
            Stats.mess++;
            GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}