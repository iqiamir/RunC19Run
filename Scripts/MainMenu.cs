using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {


            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void GameOver()
    {
        SceneManager.LoadScene(0);
        FindObjectOfType<AudioManager>().StopPlaying("Theme");
    }

    public void RetryLevel1()
    {
        SceneManager.LoadScene(1);
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void RetryLevel2()
    {
        SceneManager.LoadScene(2);
        FindObjectOfType<AudioManager>().Play("Theme");
    }

    public void win()
    {
        SceneManager.LoadScene(3);
        FindObjectOfType<AudioManager>().StopPlaying("Theme");
    }

    public void QuitGame()
    {
        Debug.Log("Quit!");
        Application.Quit();
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
}
