using UnityEngine;

public class Plate_Cleanable : ICleanable
{
    [SerializeField] private GameObject platesPrefab;
    [SerializeField] private Sink sink;


    private GameObject plates;

   
    public override void CleanMess()
    {
        if (plates != null && sink.PutDishInSink())
            Destroy(plates);
    }

    public override void SpawnMess()
    {
        print("spawn mess");

        if (transform.childCount == 0) //only spawn the plates if the table does not already have plates on it
        {
            int randomSpawn = Random.Range(0, 2);
            if (randomSpawn == 1)
            {
                Stats.mess++;
                plates = Instantiate(platesPrefab, transform);
            }
        }
    }

  
}
