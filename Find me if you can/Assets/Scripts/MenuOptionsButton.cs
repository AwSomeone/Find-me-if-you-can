using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptionsButton : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip optionsClip;

    public void PlaySound()
    {
        audioSource.PlayOneShot(optionsClip);
    }
}
