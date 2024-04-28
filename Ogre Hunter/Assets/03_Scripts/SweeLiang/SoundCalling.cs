using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundCalling : MonoBehaviour
{
    // Letting other script to be able to access
    public static SoundCalling instance;


    [Tooltip("For Summoning audio")]
    [SerializeField] private AudioSource AudioObject;



    private void Awake()
    {
        instance = this;
    }


    // If playing one sound
    public void PlaySoundFX(AudioClip audioclip, Transform spawntransform, float volume)
    {
        // Spawnning the audio object
        AudioSource audio = Instantiate(AudioObject, spawntransform.position, Quaternion.identity);

        // having the clip to be the 'audioclip'
        audio.clip = audioclip;

        // having the volume to be 'volume'
        audio.volume = volume;

        // play the audio
        audio.Play();

        // getting the length of the audioclip
        float Cliplength = audioclip.length;

        // destory the audio after the clip is done
        Destroy(audio.gameObject, Cliplength);
    }


    // If playing once the sound but wants to have multiple choices
    public void PlayRandomSoundFX(AudioClip[] audioclip, Transform spawntransform, float volume)
    {
        // Getting Random Number
        int Rand = Random.Range(0, audioclip.Length);

        // Spawnning the audio object
        AudioSource audio = Instantiate(AudioObject, spawntransform.position, Quaternion.identity);

        // having the clip to be the 'audioclip'
        audio.clip = audioclip[Rand];

        // having the volume to be 'volume'
        audio.volume = volume;

        // play the audio
        audio.Play();

        // getting the length of the audioclip
        float Cliplength = audioclip[Rand].length;

        // destory the audio after the clip is done
        Destroy(audio.gameObject, Cliplength);
    }

}
