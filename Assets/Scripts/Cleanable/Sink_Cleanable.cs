using System.Collections;
using UnityEngine;

public class Sink_Cleanable : ICleanable
{
    [SerializeField] private GameObject sinkRunning;
    [SerializeField] private Transform sinkDirty;

    [SerializeField] private Transform dishRack;

    [SerializeField] private float waitTime;


    public override void CleanMess()
    {
        sinkRunning.SetActive(true);

        StartCoroutine(CleanSink());
    }


    private IEnumerator CleanSink()
    {
        for(int i=0; i<sinkDirty.childCount; i++)
        {
            if (sinkDirty.GetChild(i).gameObject.activeSelf)
            {
                sinkDirty.GetChild(i).gameObject.SetActive(false);
                dishRack.GetChild(i).gameObject.SetActive(true);
            }

            yield return new WaitForSeconds(waitTime / sinkDirty.childCount);
        }

        sinkRunning.SetActive(false);
        sinkDirty.GetComponent<Sink>().ResetDishesInSink();
    }

    public override void SpawnMess()
    {
        StartCoroutine(TakePlate());
    }

    IEnumerator TakePlate()
    {
        for (int i = 0; i < dishRack.childCount - 1; i++) { 
            //int randomPlate = Random.Range(0, dishRack.childCount);
            dishRack.GetChild(i).gameObject.SetActive(false);

        yield return new WaitForSeconds(waitTime/dishRack.childCount); }

    }

}
