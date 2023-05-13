using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] musicClips;
    private int currentClipIndex = 0;

    private static MusicManager instance;

    public static MusicManager Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            // Move the MusicManager to a separate GameObject
            // and mark it as "Don't Destroy On Load"
            DontDestroyOnLoad(transform.root.gameObject);
        }
    }

    private void Start()
    {
        PlayNextClip();
    }

    private void Update()
    {
        if (!audioSource.isPlaying)
        {
            PlayNextClip();
        }
    }

    private void PlayNextClip()
    {
        if (musicClips.Length > 0)
        {
            audioSource.clip = musicClips[currentClipIndex];
            audioSource.Play();

            currentClipIndex++;
            if (currentClipIndex >= musicClips.Length)
            {
                currentClipIndex = 0;
            }
        }
    }

    public void PauseMusic()
    {
        if (audioSource != null) //C
        {
            audioSource.Pause();
        }
    }

    public void ResumeMusic()
    {
        if (audioSource != null)  //C
        {
            audioSource.UnPause();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null) //C
        {
            audioSource.Stop();
        }
        
        // audioSource.clip = null;
    }

   /* public void UpdateMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }*/
}
