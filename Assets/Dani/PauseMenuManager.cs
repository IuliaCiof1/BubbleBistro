using UnityEngine;

public class PauseMenuManager : MonoBehaviour
{
    [SerializeField] private GameObject pauseMenuCanvas; // Assign the pause menu canvas in the inspector

    private bool isPaused = false;

    void Start()
    {
        // Ensure the pause menu is hidden when the game starts
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false);
        }
        else
        {
            Debug.LogWarning("Pause Menu Canvas is not assigned in the inspector.");
        }
    }

    void Update()
    {
        // Listen for the Escape key to toggle the pause menu
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
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(true); // Show the pause menu
            Time.timeScale = 0f; // Pause the game physics and animations
            isPaused = true;



            // Optional: Lock the cursor
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    public void ResumeGame()
    {
        if (pauseMenuCanvas != null)
        {
            pauseMenuCanvas.SetActive(false); // Hide the pause menu
            Time.timeScale = 1f; // Resume the game physics and animations
            isPaused = false;



            // Optional: Unlock the cursor
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    public void QuitGame()
    {
        // This method can be hooked up to a Quit button in the pause menu
        Debug.Log("Quitting game...");
        Application.Quit(); // Quit the application (works only in the built version)
    }
}