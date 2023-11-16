using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioController : MonoBehaviour
{
    public Sprite audioOn;
    public Sprite audioOff;
    public GameObject buttonAudio;

    public Slider slider;

    public AudioClip clip;
    public AudioSource audioSource;

    public static AudioController instance;
    void Start()
    {
        audioSource.PlayOneShot(clip);
    }

    void Update()
    {
        audioSource.volume = slider.value;
    }
    
    public void OnOffAudio()
    {
        if (AudioListener.volume == 1)
        {
            AudioListener.volume = 0;
            buttonAudio.GetComponent<Image>().sprite = audioOff;
        }
        else
        {
            AudioListener.volume = 1;
            buttonAudio.GetComponent<Image>().sprite = audioOn;
        }
    }

    public void PlaySound()
    {
        audioSource.PlayOneShot(clip);
    }
}
