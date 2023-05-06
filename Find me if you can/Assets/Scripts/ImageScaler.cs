using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageScaler : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startClip;
    public GameObject Image;

    private bool isImageActive = false;

    public void ToggleImage()
    {
        if (!isImageActive)
        {
            audioSource.PlayOneShot(startClip);
            Image.SetActive(true);
            isImageActive = true;
        }
        else
        {
            Image.SetActive(false);
            isImageActive = false;
        }
    }
}






