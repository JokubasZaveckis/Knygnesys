using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AudioOutput : MonoBehaviour
{
    public Animator animacija;
    public void MuteToggle (bool muted)
    {
        if (muted)
        {
            AudioListener.volume = 0;
            animacija.SetBool("AudioIsON", false);
        }
        else
        {
            AudioListener.volume = 1;
            animacija.SetBool("AudioIsON", true);
        }
    }
}
