using UnityEngine;

public class Sink : MonoBehaviour
{
    private int dishesInSink;
    private int maxDishesInSink = 3;

    public bool PutDishInSink()
    {
        if (dishesInSink < maxDishesInSink)
        {
            dishesInSink++;

            foreach (Transform child in transform)
            {
                if (!child.gameObject.activeSelf)
                {
                    child.gameObject.SetActive(true);
                    break;
                }
            }

            return true;
        }

        else
        {
            Debug.Log("Sink full");
            return false;
        }
    }

    public void ResetDishesInSink()
    {
        dishesInSink = 0;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
