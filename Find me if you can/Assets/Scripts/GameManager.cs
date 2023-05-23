using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Timer timer;
    public Image shade;
    public int skipToSequence = 0;
    public GameObject infoPanel1;
    public GameObject infoPanel2;
    private bool rewind;
   // private bool loopingStarted; // G
    

    public MusicPlayer musicPlayer; 

    [Serializable]
    public class StoryMap
    {
        [Space(10)]
        public VideoClip video;
        public string sceneToStart;
        public Choice[] choice;
        public bool hasTimer;
        public AudioClip musicClip; //G 
        public bool loop;
       

        //Add a subtitle and voiceover variable?
    }

    [Serializable]
    public class Choice
    {
        public int leadsTo; //Which sequence the button should start
        public Button button;
    }

    public StoryMap[] sequences;
    //Above is the code for what can be seen on the script component in the inspector.
    //There you can put the video clips to be shown and link up buttons to make them start the next videos.

    private VideoPlayer player;
    private int currentSequence = 0;
    private int previousSequence;


    void Start()
    {
        player = GetComponent<VideoPlayer>();
        player.loopPointReached += EndReached;
        StartSequence(skipToSequence);
    }

    //Starts Video
    private void StartSequence(int sequence)
        
    {
        timer.gameObject.SetActive(false);
        player.SetDirectAudioMute(0, false); // Y
        if(!String.IsNullOrEmpty(sequences[sequence].sceneToStart))
        {
            SceneManager.LoadScene(sequences[sequence].sceneToStart);
        } 

        
         if (sequences[sequence].musicClip != null) // G
        {
           musicPlayer.PlayMusicClip(sequences[sequence].musicClip);
        }

        previousSequence = currentSequence;
        currentSequence = sequence;

        ToggleButtons(false);


      // loop
        if (sequences[currentSequence].loop)
        {
            player.isLooping = true;
        }
        player.clip = sequences[sequence].video;
        player.playbackSpeed = 1f;
        player.Play();
    }

    private void EndReached(VideoPlayer vp)
    {
        player.playbackSpeed = 1f;

        if(!sequences[currentSequence].loop)
        {
            vp.Stop();
        }

        if (sequences[currentSequence].hasTimer)
        {
            timer.gameObject.SetActive(true);
        }

/* 
        if (sequences[currentSequence].loop)
        {
            loopingStarted = true; // Set loopingStarted to true when looping starts
            musicPlayer.StopMusic(3.5f); 
        }

        if (loopingStarted) // Check if the looping has started and then reset it with the method, G
        {
            ResetLoopingStarted(); 
        }
        */

        vp.SetDirectAudioMute(0, true); // Y
        NewChoice();
    }

    //Sets up choices when video ends
    private void NewChoice()
    {
        timer.ResetTimer();

        if(currentSequence == 5 || currentSequence == 6 || currentSequence == 7)
        {
            if(infoPanel1)
            {
                infoPanel1.SetActive(true);
            }
        }else if(currentSequence == 10 || currentSequence == 11)

        {
            if (infoPanel2)
            {
                infoPanel2.SetActive(true);
            }

        }

        ToggleButtons(true);

        foreach (Choice choice in sequences[currentSequence].choice)
        {
            choice.button?.onClick.AddListener(() => StartSequence(choice.leadsTo));
            
        }

    }

    private void ToggleButtons(bool makeVisible)
    {
        if(makeVisible)
        {
            shade.color = new Color(shade.color.r, shade.color.g, shade.color.b, 0.35f);
            for (int i = 0;i <= sequences[currentSequence].choice.Length - 1;i++)
            {
                sequences[currentSequence].choice[i].button.gameObject.SetActive(true);
            }
        } else
        {
            shade.color = new Color(shade.color.r, shade.color.g, shade.color.b, 0f);
            for (int i = 0; i <= sequences[previousSequence].choice.Length - 1; i++)
            {
                sequences[previousSequence].choice[i].button.gameObject.SetActive(false);    
            }
        }
    }

    public void TimerEnded()
    {
        timer.gameObject.SetActive(false);
        StartSequence(sequences[currentSequence].choice[0].leadsTo);
    }

    public void SkipToEnd()//Y
    {
        player.time = player.clip.length;
    }

    public void SpeedUpVideo() //Y
    {
        player.playbackSpeed = 3f; // speed 3x
    }

   public void PauseGame()
    {
        player.Pause();
        
        musicPlayer.PauseMusic(); // G

    }

    public void ResumeGame()
    {
        player.Play();
        
        musicPlayer.ResumeMusic(); // G
    }

/*
    private void ResetLoopingStarted() // G
    {
        loopingStarted = false;
    }
    */

 
    
}