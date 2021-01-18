using System.Collections;
using System.Collections.Generic;
using FMOD.Studio;
using UnityEngine;

//@sevenwordsmusic original code :D !!!

public class AudioManager : MonoBehaviour
{
    public static AudioManager engine;
    [FMODUnity.EventRef]
    public string FMODEvent;

    private static int oldCode=0;

    private FMOD.Studio.EventInstance mainMusic;
    private FMOD.Studio.PARAMETER_ID segmentCodeParameterID;

    private void Awake()
    {
        if (engine != null)
        {
            GameObject.Destroy(engine);
        }
        else
        {
            engine = this;
        }
        DontDestroyOnLoad(this);
    }

    void Start()
    {
        mainMusic = FMODUnity.RuntimeManager.CreateInstance(FMODEvent);

        FMOD.Studio.EventDescription segmentCodeEventDescription;
        mainMusic.getDescription(out segmentCodeEventDescription);
        FMOD.Studio.PARAMETER_DESCRIPTION segmentCodeParameterDescription;
        segmentCodeEventDescription.getParameterDescriptionByName("SegmentCode", out segmentCodeParameterDescription);
        segmentCodeParameterID = segmentCodeParameterDescription.id;

        mainMusic.start();
    }

    public virtual void ChangeSegmentTo(int newSegmentCodeID)
    {
        if(oldCode!= newSegmentCodeID)
        {
            Debug.Log("AUDIO_ENGINE: music segment changed to: " + newSegmentCodeID);
            mainMusic.setParameterByID(segmentCodeParameterID, newSegmentCodeID);
            oldCode = newSegmentCodeID;
        }
        else
        {
            Debug.Log("AUDIO_ENGINE: already on segment code " + newSegmentCodeID + ".");
        }

    }
}
