using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenyStartButtom : MonoBehaviour
{

    [SerializeField] private AudioSource audiosource;
    [SerializeField] private AudioClip startClip;

    public void StartGame()
    {
        audiosource.PlayOneShot(startClip);
        SceneManager.LoadScene(1);
    }


}
