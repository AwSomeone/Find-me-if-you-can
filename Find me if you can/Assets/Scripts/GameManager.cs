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

    [Serializable]
    public class StoryMap
    {
        [Space(10)]
        public VideoClip video;
        public string sceneToStart;
        public Choice[] choice;

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
        StartSequence(0);
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
        timer.ResetTimer();

        player.clip = sequences[sequence].video;
        player.playbackSpeed = 1f;
        player.Play();
    }

    private void EndReached(VideoPlayer vp)
    {
        Debug.Log("video ENDED");
        vp.playbackSpeed *= 0f;
        NewChoice();
    }

    //Sets up choices when video ends
    private void NewChoice()
    {
        timer.ResetTimer();
        ToggleButtons(true);

        foreach (Choice choice in sequences[currentSequence].choice)
        {
            Debug.Log("Adding listener" + sequences[currentSequence].choice.Length);
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
        StartSequence(sequences[currentSequence].choice[0].leadsTo);
    }
}