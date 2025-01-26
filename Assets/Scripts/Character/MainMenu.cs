using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    #region - Declarations
    public Image fadeImage;
    public float fadeDuration = 1f;
    [SerializeField] private GameObject VolumeUI;
    [SerializeField] private GameObject MenuUI;
    [SerializeField] private GameObject InstructionUI;
    #endregion

    #region - Default Methods
    void Start()
    {
        
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    #endregion

    #region - Methods
    public void Play()
    {
        Stats.mess = 0;
        StartCoroutine(FadeOutAndLoadScene("Main"));
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        fadeImage.gameObject.SetActive(true);
        Color color = fadeImage.color;
        color.a = 0;
        fadeImage.color = color;

        float timer = 0f;
        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Clamp01(timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        SceneManager.LoadScene(sceneName);
    }

    public void ToggleVolumeMenu(bool showVolume)
    {
        VolumeUI.SetActive(showVolume);
        MenuUI.SetActive(!showVolume);
    }
    public void ToggleInstruction(bool showVolume)
    {
        InstructionUI.SetActive(showVolume);
        MenuUI.SetActive(!showVolume);
    }
    #endregion

}
