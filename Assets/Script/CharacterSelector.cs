using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] characterModels;
    public bool inGameplayScene = false;
    // Start is called before the first frame update
    void Start()
    {
        int selectedCharacter = PlayerPrefs.GetInt("SelectedCharacter", 0);
        if (inGameplayScene == true)
        {
            characterModels[selectedCharacter].SetActive(true);
            currentCharacterIndex = selectedCharacter;
        }
    }


    public void ChangeNext()
    {
        characterModels[currentCharacterIndex].SetActive(false);

        currentCharacterIndex++;
        if (currentCharacterIndex == characterModels.Length)
            currentCharacterIndex = 0;
        characterModels[currentCharacterIndex].SetActive(true);
    }

    public void PreviousNext()
    {
        characterModels[currentCharacterIndex].SetActive(false);

        currentCharacterIndex--;
        if (currentCharacterIndex == -1)
            currentCharacterIndex = characterModels.Length - 1;
        characterModels[currentCharacterIndex].SetActive(true);
    }
}