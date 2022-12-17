using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public enum SFX
{
    ATTACK,
    DEATH,
    HIT, 
    EVADE, 
    JUMP, 
    LAND
}

public class AudioManager : Singleton<AudioManager>
{
    public static AudioManager audioManagerInstance;

    //Switched to using Audio Mixers, this is so you can mute loads of audio sources with one command. (if we weren't using webGL you could also add effects to the audio)
    [SerializeField] bool isDontDestoryOnLoad;
    [SerializeField] AudioMixer musicMix;
    [SerializeField] AudioSource musicPlayer;
    [SerializeField] AudioSource sfxPlayer;
    [SerializeField] string musicMixName;
    [SerializeField] string sfxMixName;

    [SerializeField] AudioClip[] soundEffects;
    private bool muteSFX = true;

    void Start()
    {
        if((audioManagerInstance != null && audioManagerInstance != this))
        {
            Destroy(this);
        }
        {
            audioManagerInstance = this;
        }

        if (isDontDestoryOnLoad) DontDestroyOnLoad(gameObject);
    }

    private void SetMusic(bool isMuted)
    {
        Debug.Log("Music Playing: " + isMuted);
        musicMix.SetFloat(musicMixName, isMuted ? 0 : -80f);
    }

    private void ToggleSFX(bool isMuted)
    {
        Debug.Log("SFX Enabled: " + isMuted);
        muteSFX = isMuted;
        musicMix.SetFloat(sfxMixName, isMuted ? 0 : -80f);
    }

    public void PlaySFX(SFX sound)
    {
        if(muteSFX)
        {
            sfxPlayer.PlayOneShot(soundEffects[(int)sound], 1f);
        }
    }

    void OnEnable()
    {
        //OptionManager.OnToggleMusic += SetMusic;
        //OptionManager.OnToggleSFX += ToggleSFX;
    }

    void OnDisable()
    {
        //OptionManager.OnToggleMusic -= SetMusic;
        //OptionManager.OnToggleSFX -= ToggleSFX;
    }

    //Could fairly easily create a method for setting the volume, then have a catch that if volume is put to 0,
    // you could run the ToggleMusic (or which ever was set to 0) method in the Option Manager, thus changing the icon to match!



}
