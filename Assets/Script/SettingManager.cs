using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingManager : MonoBehaviour
{
    public GameObject pausePanel;
    public AudioManager audioManager;

    // Update is called once per frame
    void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }
    public void PauseGame()
    {
        Time.timeScale = 0;
        pausePanel.SetActive(true);
        audioManager.StopSound();
    }


    public void ResumeGame()
    {
        Time.timeScale = 1f; // mengembalikan timescale ke 1 untuk melanjutkan game
        pausePanel.SetActive(false);
        FindObjectOfType<AudioManager>().PlaySound("MainTheme");
    }

    public void QuitMenu()
    {
        SceneManager.LoadScene(0);
    }

}

