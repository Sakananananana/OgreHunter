using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class MainMenuButtonBehaviour : MonoBehaviour
{

    [SerializeField] private GameObject SettingMenu;

    [Header("Setting Panel: Volume")]
    public AudioMixerGroup SoundFxVol;
    public AudioMixerGroup MusicVol;

    [Header("Audio Clip")]
    public AudioClip[] ButtonPress;



    public void PlayBtn()
    {
        SceneManager.LoadScene(1);
    }

    public void SettingBtn()
    {
        SoundCalling.instance.PlayRandomSoundFX(ButtonPress, transform, 1);
        SettingMenu.SetActive(true);

    }


    // ====== UI In Setting Menu =======
    public void BackToMM()
    {
        SoundCalling.instance.PlayRandomSoundFX(ButtonPress, transform, 1);
        SettingMenu.SetActive(false);
    }


    public void SetSoundFxVol(float Vol)
    {
        SoundFxVol.audioMixer.SetFloat("SoundFx", Mathf.Log10(Vol) * 20);
    }

    public void SetMusicVol(float Vol)
    {
        MusicVol.audioMixer.SetFloat("Music", Mathf.Log10(Vol) * 20);
    }

    public void TutorialBtn()
    {
        SoundCalling.instance.PlayRandomSoundFX(ButtonPress, transform, 1);
        //SceneManager.LoadScene(1);
    }
}
