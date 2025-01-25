using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
    
    public Slider slider;
    public float externalValue = 0.0f; 

    void Update()
    {
        if (slider != null)
        {
            slider.value = Stats.mess;
        }
    }

    public void UpdateSliderValue(float newValue)
    {
        if (slider != null)
        {
            slider.value = newValue;
        }
    }
}