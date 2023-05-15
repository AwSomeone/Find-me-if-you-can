using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Notepad : MonoBehaviour
{
    public string textInput;
    public GameObject inputField;
    public GameObject textDisplay;


    public void SaveText()
    {
        textInput = inputField.GetComponent<Text>().text;
        textDisplay.GetComponent<Text>().text = textInput;
    }


   
}
