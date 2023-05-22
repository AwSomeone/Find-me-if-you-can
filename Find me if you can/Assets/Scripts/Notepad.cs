using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Notepad : MonoBehaviour
{
    public string textInput;
    public InputField inputField;
    public Text textDisplay;
    private string noteKey = "savedText";
  

    private void Awake()
    { 
        LoadTextFromPlayerPrefs();
    }

    public void SaveTextToPlayerPrefs()
    { 
        textInput = inputField.text;
        textDisplay.text = textInput;
            
        PlayerPrefs.SetString(noteKey, textInput);
        
    }

    public void LoadTextFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(noteKey)) 
        {
            textInput = PlayerPrefs.GetString(noteKey);
            textDisplay.text = textInput;
            inputField.text = textInput;
        }
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.SetString(noteKey, "");
    }
}


