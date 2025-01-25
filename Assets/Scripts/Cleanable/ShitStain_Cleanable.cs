using UnityEngine;

public class ShitStain_Cleanable : ICleanable
{ 
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   
    public override void CleanMess()
    {
      
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