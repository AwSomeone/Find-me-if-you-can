using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public Timer timer;
    [Serializable]
    public class StoryMap
    {
        [Space(10)]
        public VideoClip video;
        public float timeToThink;
        public Choice[] choice;
        public bool timerOrNot;

        //Add a subtitle and voiceover variable?
    }

    [Serializable]
    public class Choice
    {
        public int leadsTo; //Which sequence the button should start
        public Button button;

        public GameManager gameManagerScript;
        private Choice ()
        {
            //button.onClick.AddListener(ClickFunction);
        }
    }
    private void ClickFunction(int leadsTo)
    {
        ToggleButtons(false);
        StartSequence(leadsTo);
    }

    public StoryMap[] sequences;
    //Above is the code for what can be seen on the script component in the inspector.
    //There you can put the video clips to be shown and link up buttons to make them start the next videos.

    private VideoPlayer player;
    private int currentSequence;

    void Start()
    {
        player = GetComponent<VideoPlayer>();

        timer.gameTime = sequences[0].timeToThink; //Run this line every time the timer length needs to be set.

        StartSequence(0);
    }


    //Starts Video
    private void StartSequence(int sequence)
    {
        timer.ResetTimer();

        if(sequences[sequence] == null)
        {
            Debug.Log("Error: Sequence out of bounds of array.");
        }
        player.clip = sequences[sequence].video;
        player.playbackSpeed = 1f;
        player.Play();
        player.loopPointReached += EndReached; //Pauses video at end point
        //Assigns functions to buttonclicks
        foreach (Choice choice in sequences[0].choice)
        {
            choice.button?.onClick.AddListener(() => ClickFunction(choice.leadsTo));
        }
    }

    private void EndReached(VideoPlayer vp)
    {
        vp.playbackSpeed *= 0f;
        NewChoice();
    }

    //Sets up choices when video ends
    private void NewChoice()
    {
        timer.ResetTimer();
        ToggleButtons(true);

        foreach (Choice choice in sequences[0].choice)
        {
            choice.button?.onClick.AddListener(() => ClickFunction(choice.leadsTo));
        }

    }

    private void ToggleButtons(bool makeVisible)
    {
        foreach(Choice choice in sequences[currentSequence].choice)
        {
            choice.button.gameObject.SetActive(makeVisible); //Brings up the choices on screen
        }
    }

    public void TimerEnded()
    {
        Debug.Log("Timer ended");
        StartSequence(sequences[currentSequence].choice[0].leadsTo);
    }
}