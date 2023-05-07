using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class ShopManager : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] characterModels;
    public bool inGameplayScene = false;
    public CharacterBluePrint[] characters;
    public Button buyButton;
    public Button selectButton;
    public TextMeshProUGUI yourCoins;
        // Start is called before the first frame update
    void Start()
    {
        foreach(CharacterBluePrint ccharacter in characters)
        {
            if (ccharacter.price == 0)
                ccharacter.isUnlocked = true;
            else
                ccharacter.isUnlocked = PlayerPrefs.GetInt(ccharacter.name, 0) == 0 ? false: true ;
        }
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        if (inGameplayScene == true)
        {
            characterModels[selectedCharacter].SetActive(true);
            currentCharacterIndex = selectedCharacter;
        }

        selectButton.onClick.AddListener(SelectedCharacter);
    }

    private void Update()
    {
        UpdateUI();
        int coinValue = PlayerPrefs.GetInt("NumberOfCoins");
        yourCoins.SetText("Coins : " + coinValue.ToString());
    }


    public void ChangeNext()
    {
        characterModels[currentCharacterIndex].SetActive(false);

        currentCharacterIndex++;
        if (currentCharacterIndex == characterModels.Length)
            currentCharacterIndex = 0;
        characterModels[currentCharacterIndex].SetActive(true);
        CharacterBluePrint c = characters[currentCharacterIndex];
        if (!c.isUnlocked)
            return;
    }

    public void PreviousNext()
    {
        characterModels[currentCharacterIndex].SetActive(false);

        currentCharacterIndex--;
        if (currentCharacterIndex == -1)
            currentCharacterIndex = characterModels.Length - 1;
        characterModels[currentCharacterIndex].SetActive(true);
        CharacterBluePrint c = characters[currentCharacterIndex];
        if (!c.isUnlocked)
            return;
    }

    public void SelectedCharacter()
    {
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
        SceneManager.LoadScene(0);
    }
    

    public void UnlockCharacter()
    {
        CharacterBluePrint c = characters[currentCharacterIndex];
        PlayerPrefs.SetInt(c.name, 1);
        PlayerPrefs.SetInt("SelectedCharacter", currentCharacterIndex);
        c.isUnlocked = true;
        PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - c.price);

    }


    private void UpdateUI()
    {
        CharacterBluePrint c = characters[currentCharacterIndex];
        if (c.isUnlocked)
        {
            buyButton.gameObject.SetActive(false);
            selectButton.gameObject.SetActive(true);
        }
        else
        {
            buyButton.gameObject.SetActive(true);
            selectButton.gameObject.SetActive(false);
            buyButton.GetComponentInChildren<TextMeshProUGUI>().text = "Coins " + c.price;
            if (c.price < PlayerPrefs.GetInt("NumberOfCoins"))
            {
                buyButton.interactable = true;
            }
            else
            {
                buyButton.interactable = false;
            }
        }

    }
}
