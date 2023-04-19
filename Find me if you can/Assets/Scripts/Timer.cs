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
    }

    void Update()
    {
        float time = gameTime - Time.time;

        int seconds = Mathf.FloorToInt(time / 60f);

        if(time <= 0)
        {
            stopTimer = true;
            gm.TimerEnded();
        }

        if(stopTimer == false)
        {
            timerSlider.value = time; 
        }
    }
}
