using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelector : MonoBehaviour
{
    public int currentCharacterIndex;
    public GameObject[] characterModel;    // Start is called before the first frame update
    void Start()
    {
        currentCharacterIndex = PlayerPrefs.GetInt("SelectedCharacter", 0);
        foreach (GameObject characterMods in characterModel)
            characterMods.SetActive(false);

        characterModel[currentCharacterIndex].SetActive(true);

    }
}
