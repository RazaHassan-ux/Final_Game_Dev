using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseMenuPanel;
    public GameObject optionsPanel;
    public GameObject Canvas;


    bool isPaused = false;

    void Update()
    {
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
        Canvas.SetActive(true);
        pauseMenuPanel.SetActive(true);
        optionsPanel.SetActive(false);
        Time.timeScale = 0f;
        isPaused = true;
    }

    public void ResumeGame()
    {
        Canvas.SetActive(false);
        pauseMenuPanel.SetActive(false);
        optionsPanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void OpenOptions()
    {
        pauseMenuPanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Time.timeScale = 1f;
        Application.Quit();
    }
}
