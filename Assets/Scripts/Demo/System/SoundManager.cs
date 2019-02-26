using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    private AudioSource audioSource;
    public static int on = 1;

    private void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        audioSource = GetComponent<AudioSource>();
        on = 1;
    }


    public void PlayMusic()
    {
        on = 1;
    }

    public void StopMusic()
    {
        on = 0;
    }

    public AudioListener audioListener;
   


    void OnMouseDown()
    {
        on = 1;
       
    }
}
