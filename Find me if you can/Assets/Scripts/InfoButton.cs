using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InfoButton : MonoBehaviour
{
    public GameObject Panel;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip startClip;

    public void OpenPanel() {

        if(Panel != null) {

            audioSource.PlayOneShot(startClip);
            bool isActive = Panel.activeSelf;
            Panel.SetActive(!isActive);
        }
    }
}
