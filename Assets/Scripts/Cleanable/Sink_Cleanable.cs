using System.Collections;
using UnityEngine;

public class Sink_Cleanable : ICleanable
{
    [SerializeField] public AudioClip WashStart;
    [SerializeField] public AudioClip WashEnd;
    [SerializeField] private GameObject sinkRunning;
    [SerializeField] private Transform sinkDirty;
    private bool setAudio = true;
    private bool iscleaning = false;
    [SerializeField] private Transform dishRack;

    [SerializeField] private float waitTime;


    public override void CleanMess()
    {
        if(!iscleaning)
            StartCoroutine(CleanSink());
    }


    private IEnumerator CleanSink()
    {

        print("cleansink");
        for (int i = 0; i < sinkDirty.childCount; i++)
        {
            iscleaning = true;
            if (sinkDirty.GetChild(i).gameObject.activeSelf)
            {
                sinkRunning.SetActive(true);
                if (setAudio = true)
                {
                    SoundFXManager.instance.PlaySoundFXClip(WashStart, transform, 1f);
                    setAudio = false;
                }
                Stats.mess = Stats.mess - 4;
                sinkDirty.GetChild(i).gameObject.SetActive(false);
                dishRack.GetChild(i).gameObject.SetActive(true);
                yield return new WaitForSeconds(waitTime / sinkDirty.childCount);
            } 
        }
        if (setAudio = false)
        {
            setAudio = true;
        }
        //SoundFXManager.instance.StopAudio();
        //SoundFXManager.instance.PlaySoundFXClip(WashEnd, transform, 1f);
        sinkRunning.SetActive(false);
        sinkDirty.GetComponent<Sink>().ResetDishesInSink();
        iscleaning = false;
    }

    public override void SpawnMess()
    {
        StartCoroutine(TakePlate());
    }

    IEnumerator TakePlate()
    {
        for (int i = 0; i < dishRack.childCount - 1; i++)
        {
            //int randomPlate = Random.Range(0, dishRack.childCount);
            dishRack.GetChild(i).gameObject.SetActive(false);

            yield return new WaitForSeconds(waitTime / dishRack.childCount);
        }

    }

}
