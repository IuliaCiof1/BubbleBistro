using UnityEngine;
using UnityEngine.UI;

public class SliderUpdater : MonoBehaviour
{
    
    public Slider slider;
    public float externalValue = 0.0f;
    public GameObject endMenuCanvas;
    public Controller player;


    void Update()
    {
        if (Stats.mess <= slider.maxValue)
        {
            if (slider != null)
            {
                slider.value = Stats.mess;
            }
        }
        else
        {
            slider.value = Stats.mess;
            Debug.Log("You lost!");
            Time.timeScale = 0f;
            endMenuCanvas.SetActive(true);
            player.canMove = false;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;


        }
    }

    public void UpdateSliderValue(float newValue)
    {
        print(newValue + " value " + slider.maxValue);
        if(newValue < slider.maxValue)
            if (slider != null)
            {
                slider.value = newValue;
            }
        else
        {
            
                Debug.Log("You lost!");
                Time.timeScale = 0f;
                endMenuCanvas.SetActive(true);
                player.canMove = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            
        }
    }
}