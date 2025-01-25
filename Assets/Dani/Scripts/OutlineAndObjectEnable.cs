using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class OutlineManager : MonoBehaviour
{
    [System.Serializable]
    public class ImageWithOutline
    {
        public Image image;
        public Outline outline;
    }

    [SerializeField]
    private List<ImageWithOutline> imagesWithOutlines = new List<ImageWithOutline>();
    [SerializeField]
    private List<GameObject> objectsToActivate = new List<GameObject>();
    private int currentlyActiveIndex = -1;

    private void Update()
    {
        for (int i = 0; i < imagesWithOutlines.Count; i++)
        {
            if (Input.GetKeyDown(KeyCode.Alpha1 + i))
            {
                if (currentlyActiveIndex == i)
                {
                    DeactivateAll();
                    currentlyActiveIndex = -1;
                }
                else
                {
                    ActivateOutlineAndObject(i);
                    currentlyActiveIndex = i;
                }
                break;
            }
        }
    }

    private void ActivateOutlineAndObject(int index)
    {
        for (int i = 0; i < imagesWithOutlines.Count; i++)
        {
            if (imagesWithOutlines[i].outline != null)
            {
                imagesWithOutlines[i].outline.enabled = (i == index);
            }
        }

        for (int i = 0; i < objectsToActivate.Count; i++)
        {
            objectsToActivate[i].SetActive(i == index);
        }
    }

    private void DeactivateAll()
    {
        foreach (var item in imagesWithOutlines)
        {
            if (item.outline != null)
            {
                item.outline.enabled = false;
            }
        }

        foreach (var obj in objectsToActivate)
        {
            obj.SetActive(false);
        }
    }

    public void AddImageWithOutline(Image image, Outline outline)
    {
        imagesWithOutlines.Add(new ImageWithOutline { image = image, outline = outline });
    }

    public void AddObjectToActivate(GameObject obj)
    {
        objectsToActivate.Add(obj);
    }
}
