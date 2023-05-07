using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(50 * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FindObjectOfType<AudioManager>().PlaySound("CoinPickUp");
            PlayerManager.numberOfCoins += 1;
            if (PlayerManager.numberOfCoins > PlayerManager.highNumberCoins)
            {
                PlayerManager.highNumberCoins = PlayerManager.numberOfCoins;
                PlayerPrefs.SetInt("NumberOfCoins", PlayerManager.numberOfCoins);
                PlayerPrefs.SetInt("highscore", PlayerManager.highNumberCoins);
            }
            Destroy(gameObject);
        }
    }

}
