using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class MusicPlayer : MonoBehaviour
{

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip musicClip;
    public float musicVolume = 1f;
    public Slider volumeSlider;

    public VideoPlayer videoPlayer;

    public MusicManager musicManager;

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
      //  musicManager.UpdateMusicVolume(volume);
    }

    
}
