using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
public class SkipVideo : MonoBehaviour, IPointerClickHandler
{
    public GameManager gm;
    private DateTime clickedFirstTime;
    private const int DOUBLE_CLICK_MILLISECONDS_BETWEEN = 500; //så länge vi ska vänta mellan click
    private int clickCount = 0; 

    // Start is called before the first frame update
    void Start()
    {
        //när programmet startar så säger det att jag klickade för första gången för 2 sec tidigare
        clickedFirstTime = DateTime.Now.AddSeconds(-2);
         
    }

    public void OnPointerClick(PointerEventData pointerEventData)
    {
        var timeBetweenClicks = DateTime.Now - clickedFirstTime;

        if (timeBetweenClicks.TotalMilliseconds > DOUBLE_CLICK_MILLISECONDS_BETWEEN)
        {
            clickedFirstTime = DateTime.Now;
            clickCount = 1;
        }
        else
        {
            clickCount++;
            
            if (clickCount == 2)
            {
                gm.SpeedUpVideo();
            }
            else if (clickCount == 3)
            {
                gm.SkipToEnd();

            }
        }
    }
}