using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip musicClip;
    public float musicVolume = 1f;
    public Slider volumeSlider;

    // Start is called before the first frame update
    void Start()
    {
     
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
        musicVolume = PlayerPrefs.GetFloat("volume");
        audioSource.volume = musicVolume;
        volumeSlider.value = musicVolume;

        
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
        PlayerPrefs.SetFloat("volume", musicVolume);
    }

   public void updateVolume(float volume)
    {
       
        musicVolume = volume;
    }
}
