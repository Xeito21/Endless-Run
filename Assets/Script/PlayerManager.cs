using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager instance;
    public static bool gameOver;
    public GameObject gameOverPanel;
    public static bool isGameStarted;
    public GameObject startingText;

    public static int numberOfCoins = 0;
    public static int highNumberCoins = 0;
    public TMP_Text coinsText;
    public TMP_Text highcoinsText;

    // Start is called before the first frame update
    public void Start()
    {
        gameOver = false;
        Time.timeScale = 1;
        isGameStarted = false;

        highNumberCoins = PlayerPrefs.GetInt("HighScore", 0);
        highcoinsText.text = "Highscore : " + numberOfCoins.ToString();
        numberOfCoins = PlayerPrefs.GetInt("NumberOfCoins", 0);
        coinsText.text = "Coins: " + numberOfCoins.ToString();
    }

    public void Update()
    {
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            if (numberOfCoins > highNumberCoins)
            {
                highNumberCoins = numberOfCoins;
                PlayerPrefs.SetInt("HighScore", highNumberCoins);
                highcoinsText.text = "Highscore : " + highNumberCoins.ToString();
            }
        }

        coinsText.text = "Coins:" + numberOfCoins;
        if (SwipeController.tap)
        {
            isGameStarted = true;
            Destroy(startingText);
        }
    }
}

