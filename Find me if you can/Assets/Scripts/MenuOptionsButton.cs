using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuOptionsButton : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startClip;

    public void Start()
    {
        audioSource.PlayOneShot(startClip);
    }
}
