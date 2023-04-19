using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Timer : MonoBehaviour
{
    [NonSerialized]
    public float gameTime = 10f;
    private Slider timerSlider;
    private bool stopTimer;

    void Start()
    {
        timerSlider = gameObject.GetComponent<Slider>();
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
        }

        if(stopTimer == false)
        {
            timerSlider.value = time; 
        }
    }
}
