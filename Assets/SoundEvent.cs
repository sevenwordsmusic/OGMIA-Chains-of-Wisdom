using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

//@sevenwordsmusic original code :D !!!

public class SoundEvent : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string stepEvent;
    [FMODUnity.EventRef]
    public string swingEvent;

    private bool isIdle=true;

    public void yesIdle()
    {
        isIdle = true;
    }

    public void noIdle()
    {
        isIdle = false;
    }

    public void playStep()
    {
        if (!isIdle)
        {
            FMODUnity.RuntimeManager.CreateInstance(stepEvent).start();
        }

    }

    public void playSwing()
    {
        FMODUnity.RuntimeManager.CreateInstance(swingEvent).start();
    }
}