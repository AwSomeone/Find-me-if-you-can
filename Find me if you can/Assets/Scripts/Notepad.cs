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
    private bool gameStarted = false;

    /*public void Start()
    {
        // Återställ vid start
        PlayerPrefs.SetString(noteKey, "");
    }*/

    private void Awake()
    {
        LoadTextFromPlayerPrefs();
    }

    public void StartGame()
    {
        gameStarted = true;
        
    }

    public void SaveTextToPlayerPrefs()
    {
        if (gameStarted)
        {
            textInput = inputField.text;
            textDisplay.text = textInput;

            // Kontrollera att texten hämtas korrekt
            Debug.Log("Input Field Text: " + textInput); 
            

            PlayerPrefs.SetString(noteKey, textInput);
            //PlayerPrefs.Save();
        }
    }

    public void LoadTextFromPlayerPrefs()
    {
        if (PlayerPrefs.HasKey(noteKey) && gameStarted) 
        {
            textInput = PlayerPrefs.GetString(noteKey);
            textDisplay.text = textInput;
            inputField.text = textInput;
        }
    }

    /*public void OnEndEditText(string newText)
    {
        textInput = newText;
        SaveTextToPlayerPrefs();
    }*/
}


