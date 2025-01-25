using UnityEngine;
using UnityEngine.UI;

public class SurvivalMeter : MonoBehaviour
{
    public Slider slider;
    public float timerDuration = 300f;
    public GameObject endMenuCanvas;
    private float currentTime;
    public Controller player;

    void Start()
    {
        if (slider != null)
        {
            slider.maxValue = timerDuration;
            slider.value = timerDuration;
        }
        currentTime = timerDuration;
    }

    void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;

            if (slider != null)
            {
                slider.value = Mathf.Clamp(currentTime, 0, timerDuration);
            }
        }
        else
        {
            if (currentTime != 0)
            {
                Debug.Log("You won!");
                currentTime = 0;
                Time.timeScale = 0f;
                endMenuCanvas.SetActive(true);
                player.canMove = false;
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
            }
        }
    }

    public void UpdateSliderValue(float newValue)
    {
        if (slider != null)
        {
            slider.value = Mathf.Clamp(newValue, 0, timerDuration);
            currentTime = newValue;
        }
    }
}
