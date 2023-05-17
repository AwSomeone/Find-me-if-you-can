using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Notepad : MonoBehaviour
{
    public string textInput;
    public GameObject inputField;
    //public GameObject textDisplay;
    private string noteKey = "savedText";


    private void Start()
    {
        //återställ vid start
        PlayerPrefs.SetString(noteKey, "");
    }

    public void SaveText()
    {
        textInput = inputField.GetComponent<Text>().text;
        //textDisplay.GetComponent<Text>().text = textInput;

        Debug.Log("Input Field Text: " + textInput); // Kontrollera att texten hämtas korrekt
        Debug.Log("Input Field Object: " + inputField.name);

        PlayerPrefs.SetString(noteKey, textInput);
        PlayerPrefs.Save();
    }

    private void OnEnable()
    {
        //if (PlayerPrefs.HasKey(noteKey))
        //{
            textInput = PlayerPrefs.GetString(noteKey);
            //textDisplay.GetComponent<Text>().text = textInput;
        //}
    }


}
