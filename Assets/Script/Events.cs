using UnityEngine.SceneManagement;
using UnityEngine;

public class Events : MonoBehaviour
{
    // Start is called before the first frame update
    public void ReplayGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void QuitGame()
    {
        SceneManager.LoadScene(0);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

}
