using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InfoPanel : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    public float minPause = 0.01f;
    public float maxPause = 0.1f;
    public float minPitch = 1f;
    public float maxPitch = 1f;
    public float startDelay = 0.1f;
    private float pausTime;
    public AudioSource typeSound;
    public bool playSound = true;

    private int index;
 
    void OnEnable()
    {
        textComponent.text = string.Empty;
        StartText();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) {
            NextLine();
        }
    }

    void StartText() {

        index = 0;
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine() {
        foreach (char c in lines[index].ToCharArray()) {
            textComponent.text += c;
         
            if (playSound) {
                typeSound.pitch = Random.Range(minPitch, maxPitch);
                typeSound.Play();
                yield return new WaitForSeconds(textSpeed);
            }
            if(lines.ToString().Contains(",") || lines.ToString().Contains("!") || lines.ToString().Contains(".")) {
                pausTime = Random.Range(minPause, maxPause);
            }
         
            yield return new WaitForSeconds(pausTime);
        }
    }

    void NextLine() {
        if(index < lines.Length - 1) {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else {
            gameObject.SetActive(false);
        }
    }
}
