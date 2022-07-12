using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioControl : MonoBehaviour
{
    public AudioSource clickUI;


    void Start()
    {
        
    }

    
    void Update()
    {
        
    }

    public void playSound()
    {
        clickUI.Play();
    }
}
