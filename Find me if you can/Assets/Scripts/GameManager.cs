using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using System;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    [Serializable]
    public class StoryMap
    {
        [Space(10)]
        public VideoClip video;
        public float timeToThink;
        public Timer timer;
        public Choice[] choice;

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
            button.onClick.AddListener(ClickFunction);
        }
        private void ClickFunction()
        {
            gameManagerScript.ToggleButtons(false);
            gameManagerScript.StartSequence(leadsTo);
        }
    }

    public StoryMap[] sequences;
    //Above is the code for what can be seen on the script component in the inspector.
    //There you can put the video clips to be shown and link up buttons to make them start the next videos.

    private VideoPlayer player;
    private int currentSequence;

    void Start()
    {
        player = GetComponent<VideoPlayer>();

        sequences[0].timer.gameTime = sequences[0].timeToThink; //Run this line every time the timer length needs to be set.

        StartSequence(0);
    }


    //Starts Video
    private void StartSequence(int sequence)
    {
        if(sequences[sequence] == null)
        {
            Debug.Log("Error: Sequence out of bounds of array.");
        }
        player.clip = sequences[sequence].video;
        player.Play();
        player.loopPointReached += EndReached; //Pauses video at end point
    }

    private void EndReached(VideoPlayer vp)
    {
        vp.playbackSpeed *= 0f;
        NewChoice();
    }


    //Sets up choices when video ends
    private void NewChoice()
    {
        ToggleButtons(true);
    }

    private void ToggleButtons(bool makeVisible)
    {
        foreach(Choice choice in sequences[currentSequence].choice)
        {
            choice.button.gameObject.SetActive(true); //Brings up the choices on screen
        }
    }
}
