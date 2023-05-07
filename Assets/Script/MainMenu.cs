
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        Screen.SetResolution(Screen.width, Screen.height, true);
    }
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Level");
    }


    public void ShopMenu()
    {
        SceneManager.LoadScene("Shop");
    }


    public void QuitGame()
    {
        Application.Quit();
    }
}
