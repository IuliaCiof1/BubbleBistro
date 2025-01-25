using UnityEngine;

public class Plate_Cleanable : MonoBehaviour, ICleanable
{
    [SerializeField] private GameObject platesPrefab;
    [SerializeField] private Sink sink;


    private GameObject plates;

    private void Start()
    {
        int randomSpawn = Random.Range(0, 2);
        if(randomSpawn == 1)
            SpawnMess();
    }

    public void CleanMess()
    {
        sink.PutDishInSink();

        Destroy(plates);
    }

    public void SpawnMess()
    {
        Stats.mess++;

        plates = Instantiate(platesPrefab, transform);
    }


}
