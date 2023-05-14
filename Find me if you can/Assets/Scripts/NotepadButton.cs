using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotepadButton : MonoBehaviour
{
    public GameObject notepad;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startClip;
   

    public void ShowNotePad() {

        if(notepad != null) {

            audioSource.PlayOneShot(startClip);
            bool isActive = notepad.activeSelf;
            notepad.SetActive(!isActive);
        }
    }
}
