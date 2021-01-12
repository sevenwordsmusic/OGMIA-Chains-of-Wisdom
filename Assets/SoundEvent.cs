using UnityEngine;
using FMOD.Studio;
using FMODUnity;
using System.Collections;

//@sevenwordsmusic original code :D !!!

public class SoundEvent : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string stepEvent;
    private FMOD.Studio.EventInstance eventToPlay;

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
            eventToPlay = FMODUnity.RuntimeManager.CreateInstance(stepEvent);
            eventToPlay.start();
        }

    }
}