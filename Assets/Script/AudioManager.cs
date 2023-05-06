using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Slider volumeSlider;
    // Start is called before the first frame update


    void Start()
    {
        // Set the slider value based on the saved volume value
        float savedVolume = PlayerPrefs.GetFloat("volume", 0.5f);
        volumeSlider.value = savedVolume;
    }

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
        }
        PlaySound("MainTheme");
        float savedVolume = PlayerPrefs.GetFloat("volume", 1f);
        SetVolume(savedVolume);
    }


    public void PlaySound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Play();
        }

    }
    public void StopSound()
    {
        foreach (Sound s in sounds)
        {
            s.source.Stop();
        }
    }

    public void StopSound(string name)
    {
        foreach (Sound s in sounds)
        {
            if (s.name == name)
                s.source.Stop();
        }
    }

    public void SetVolume(float volume)
    {
        foreach (Sound s in sounds)
        {
            s.source.volume = volume;
        }
        PlayerPrefs.SetFloat("volume", volume);
    }


}

