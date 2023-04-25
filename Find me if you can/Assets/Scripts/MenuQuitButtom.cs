using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuQuitButtom : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip quitClip;

    public void QuitGame()
    {
        audioSource.PlayOneShot(quitClip);

        Application.Quit();
    }
}
