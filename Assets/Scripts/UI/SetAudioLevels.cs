using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using FMOD.Studio;

//AUDIO by @sevenwordsmusic - Got it memorized?
public class SetAudioLevels : MonoBehaviour {

    private FMOD.Studio.Bus bgmBus;
    private FMOD.Studio.Bus sfxBus;

    public void SetMusicLevel(float musicLvl)
	{

        bgmBus=FMODUnity.RuntimeManager.GetBus("bus:/BGM_bus");
        bgmBus.setVolume(musicLvl);
    }

	public void SetSfxLevel(float sfxLevel)
	{
        sfxBus=FMODUnity.RuntimeManager.GetBus("bus:/SFX_bus");
        sfxBus.setVolume(sfxLevel);
    }
}
