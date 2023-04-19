using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public GameManager gm;

    [NonSerialized]
    public float gameTime = 10f;
    private Slider timerSlider;
    private bool stopTimer;
    private float elapsedTime;

    void Start()
    {
        timerSlider = gameObject.GetComponent<Slider>();
        ResetTimer();
    }

    public void ResetTimer()
    {
        Debug.Log("Timer reset to" + gameTime);
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        elapsedTime = 0;
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        Debug.Log("Time: " + elapsedTime);

        if(stopTimer == false)
        {
            timerSlider.value -= gameTime/elapsedTime; 
        }
        if(elapsedTime >= gameTime)
        {
            elapsedTime = gameTime;

            stopTimer = true;
            gm.TimerEnded();
            ResetTimer();
        }

    }
}
