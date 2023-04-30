using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip musicClip;
    public float musicVolume = 1f;

    // Start is called before the first frame update
    void Start()
    {
     
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        audioSource.volume = musicVolume;
    }

   public void updateVolume(float volume)
    {
       
        musicVolume = volume;
    }
}
