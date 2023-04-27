using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    public GameManager gm;

    [NonSerialized]
    public float gameTime = 5f;
    public Slider timerSlider;
    private bool stopTimer = true;
    private float elapsedTime;

    void OnEnable()
    {
        timerSlider = gameObject.GetComponent<Slider>();
        ResetTimer();
    }

    public void ResetTimer()
    {
        Debug.Log("TIMER RESET");
        stopTimer = false;
        timerSlider.maxValue = gameTime;
        timerSlider.value = gameTime;
        elapsedTime = -1;
    }

    void Update()
    {
        Debug.Log(stopTimer);
        if(!stopTimer)
        {
            elapsedTime += Time.deltaTime;
            timerSlider.value = gameTime - elapsedTime;
        }

        if(elapsedTime >= gameTime)
        {
            gameTime = 5f;

            stopTimer = true;
            gm.TimerEnded();
        }

    }
}
