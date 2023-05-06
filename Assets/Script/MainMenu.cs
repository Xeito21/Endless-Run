
using UnityEngine.SceneManagement;
using UnityEngine;

public class MainMenu : MonoBehaviour
{

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

