using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas; // Assign your Canvas in the Inspector
    public MonoBehaviour cameraController; // Assign the camera movement script here (e.g., CameraController)
    private bool isPaused = false;

    void Update()
    {
        // Listen for Escape key press
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        // Show the pause menu and pause time
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        // Disable the camera controller to lock the camera
        if (cameraController != null)
        {
            cameraController.enabled = false;
        }
    }

    public void ResumeGame()
    {
        // Hide the pause menu and resume time
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        // Enable the camera controller to unlock the camera
        if (cameraController != null)
        {
            cameraController.enabled = true;
        }
    }

    public void QuitGame()
    {
        // Quit the application
        Debug.Log("Quitting the game..."); // This message shows in the editor for testing
        Application.Quit(); // This will quit the game in a built application
    }
}
