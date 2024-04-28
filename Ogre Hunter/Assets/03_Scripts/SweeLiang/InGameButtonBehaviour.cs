using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class InGameButtonBehaviour : MonoBehaviour
{
    [Header("Button Declaration")]
    [SerializeField] private GameObject SettingMenu;
    [SerializeField] private GameObject PauseMenu;


    [Header("Setting Panel: Volume")]
    public AudioMixerGroup SoundFxVol;
    public AudioMixerGroup MusicVol;


    [Header("Audio Clip")]
    public AudioClip[] ButtonPress;


    // For Lowering the volume of background music
    private float CurrentVol;


    public void PauseBtn()
    {
        SoundCalling.instance.PlayRandomSoundFX(ButtonPress, transform, 1);
        Time.timeScale = 0.0f;
        PauseMenu.SetActive(true);
        MusicVol.audioMixer.GetFloat("Music", out CurrentVol);
        MusicVol.audioMixer.SetFloat("Music", CurrentVol - 10);
    }

    public void BackToMainMenuBtn()
    {
        SoundCalling.instance.PlayRandomSoundFX(ButtonPress, transform, 1);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene(0);
    }

    public void ContinueBtn()
    {
        SoundCalling.instance.PlayRandomSoundFX(ButtonPress, transform, 1);
        Time.timeScale = 1.0f;
        PauseMenu.SetActive(false);
        MusicVol.audioMixer.SetFloat("Music", CurrentVol);
    }


    public void SettingBtn()    
    {
        MusicVol.audioMixer.SetFloat("Music", CurrentVol);
        SoundCalling.instance.PlayRandomSoundFX(ButtonPress, transform, 1);
        SettingMenu.SetActive(true);

    }

    // ====== UI In Setting Menu =======
    public void BackToPause()
    {
        SoundCalling.instance.PlayRandomSoundFX(ButtonPress, transform, 1);
        SettingMenu.SetActive(false);
        MusicVol.audioMixer.GetFloat("Music", out CurrentVol);
        MusicVol.audioMixer.SetFloat("Music", CurrentVol - 10);
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
