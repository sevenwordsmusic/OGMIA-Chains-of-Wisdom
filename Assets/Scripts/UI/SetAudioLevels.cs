using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using FMOD.Studio;


public class SetAudioLevels : MonoBehaviour {

    private FMOD.Studio.Bus bgmBus;
    private FMOD.Studio.Bus sfxBus;


    //AUDIO by @sevenwordsmusic
    public void SetMusicLevel(float musicLvl)
	{

        bgmBus=FMODUnity.RuntimeManager.GetBus("bus:/BGM_bus");
        Debug.Log(bgmBus);
        bgmBus.setVolume(musicLvl);
    }

	//AUDIO by @sevenwordsmusic
	public void SetSfxLevel(float sfxLevel)
	{
        sfxBus=FMODUnity.RuntimeManager.GetBus("bus:/SFX_bus");
        sfxBus.setVolume(sfxLevel);
    }
}
