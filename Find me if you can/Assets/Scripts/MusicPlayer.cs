using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Collections;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip musicClip;
    public float musicVolume = 1f;
    public Slider volumeSlider;

    public VideoPlayer videoPlayer;


    // Start is called before the first frame update
    void Start()
    {
       // videoPlayer = gm.GetComponent<VideoPlayer>();

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
        videoPlayer.SetDirectAudioVolume(0, musicVolume);
       
    }

   public void updateVolume(float volume)
    {
       
        musicVolume = volume;
      
    }

    public void PlayMusicClip(AudioClip clip) // G
    {
        audioSource.clip = clip;
        audioSource.Play();
    }

    public void PauseMusic() // G
    {
        if (audioSource != null)
        {
            audioSource.Pause();
        }
    }

    public void ResumeMusic() // G 
    {
        if (audioSource != null)
        {
            audioSource.UnPause();
        }
    }

    //Stops music and call on the fade out music, so it's no hard cut
   public void StopMusic(float fadeDuration = 1f) // G
{
    StartCoroutine(FadeOutMusic(fadeDuration));
}

    private IEnumerator FadeOutMusic(float fadeDuration) // G
{
    float startVolume = audioSource.volume;
    float timer = 0f;

    while (timer < fadeDuration)
    {
        timer += Time.deltaTime;
        audioSource.volume = Mathf.Lerp(startVolume, 0f, timer / fadeDuration);
        yield return null;
    }

    audioSource.Stop();
    audioSource.volume = startVolume; // Reset volume to original 
}
    
}
