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
    public GameObject dialogueBox;
    private bool rewind;


    [Serializable]
    public class StoryMap
    {
        [Space(10)]
        public VideoClip video;
        public string sceneToStart;
        public Choice[] choice;
        public bool hasTimer;

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
        if(!String.IsNullOrEmpty(sequences[sequence].sceneToStart))
        {
            SceneManager.LoadScene(sequences[sequence].sceneToStart);
        }

        

        previousSequence = currentSequence;
        currentSequence = sequence;

        ToggleButtons(false);
        //timer.ResetTimer();

        Debug.Log("Changing video");
        rewind = false;
        player.clip = sequences[sequence].video;
        player.playbackSpeed = 1f;
        player.Play();
    }

    private void Update()
    {
        if (rewind == true)
        {
            Debug.Log("REWINDING" + player.frame);
            player.frame = player.frame + 5; // can get fancy here if you want, this is super basic
        }
    }

    private void EndReached(VideoPlayer vp)
    {
        rewind = true;
        vp.Stop();
        //Debug.Log("video ENDED");
        //vp.playbackSpeed *= 0f;

        if (sequences[currentSequence].hasTimer)
        {
            timer.gameObject.SetActive(true);
        }

        NewChoice();
    }

    //Sets up choices when video ends
    private void NewChoice()
    {
        timer.ResetTimer();

        if(currentSequence == 5 || currentSequence == 6 || currentSequence == 7 || currentSequence == 10 || currentSequence == 11)
        {
            if(dialogueBox)
            {
                dialogueBox.SetActive(true);
            }
        }

        ToggleButtons(true);

        foreach (Choice choice in sequences[currentSequence].choice)
        {
            //Debug.Log("Adding listener" + sequences[currentSequence].choice.Length);
            choice.button?.onClick.AddListener(() => StartSequence(choice.leadsTo));
        }

    }

    private void ToggleButtons(bool makeVisible)
    {
        if(makeVisible)
        {
            shade.color = new Color(shade.color.r, shade.color.g, shade.color.b, 0.22f);
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
        Debug.Log("TIMER ENDED");
        timer.gameObject.SetActive(false);
        StartSequence(sequences[currentSequence].choice[0].leadsTo);
    }

    public void SkipToEnd()
    {
        player.time = player.clip.length;
    }

    public void SpeedUpVideo()
    {
        player.playbackSpeed = 3f; // speed 3x
    }

   public void PauseGame()
    {
        // player.time = player.clip.frameRate;
        player.Pause();

    }

    public void ResumeGame()
    {
        player.Play();
    }
}