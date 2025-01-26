using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuCanvas;
    public GameObject endMenuCanvas;
    public MonoBehaviour cameraController;
    public Controller player;
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
        pauseMenuCanvas.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;

        player.canMove = false;
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        if (cameraController != null)
        {
            cameraController.enabled = false;
        }
    }

    public void ResumeGame()
    {
        pauseMenuCanvas.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;

        player.canMove = true;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        if (cameraController != null)
        {
            cameraController.enabled = true;
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quitting the game...");
        Application.Quit();
    }
    public void ReturnToMainMenu()
    {
        Debug.Log("Returning to the main menu...");
        SceneManager.LoadScene("Main Menu");
    }
}
