using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
}

public class SoundControl : MonoBehaviour
{
    public static SoundControl instance;

    public AudioSource[] audioSourceEffects;
    public AudioSource[] otherEffects;
    public AudioSource audioSourceBackground;

    public string[] playSoundName;

    public Sound[] soundEffects;
    public Sound soundBackgrounds;

    private void Start()
    {
        SoundControl.instance = this;
        playSoundName = new string[audioSourceEffects.Length];

        if (soundBackgrounds != null)
        {
            audioSourceBackground.clip = soundBackgrounds.clip;
            audioSourceBackground.Play();
        }

        for (int i = 0; i < audioSourceEffects.Length; ++i)
        {
            audioSourceEffects[i].volume = PlayerPrefs.GetFloat("Effect");
        }

        for (int i = 0; i < otherEffects.Length; ++i)
        {
            otherEffects[i].volume = PlayerPrefs.GetFloat("Effect");
        }

        audioSourceBackground.volume = PlayerPrefs.GetFloat("BGM");
    }

    public void PlaySE(string sound)
    {
        for (int i = 0; i < soundEffects.Length; ++i)
        {
            if (sound == soundEffects[i].name)
            {
                for (int j = 0; j < audioSourceEffects.Length; ++j)
                {
                    if (!audioSourceEffects[j].isPlaying)
                    {
                        playSoundName[j] = soundEffects[i].name;
                        audioSourceEffects[j].clip = soundEffects[i].clip;
                        audioSourceEffects[j].Play();
                        return;
                    }
                    else if (audioSourceEffects[j].clip == soundEffects[i].clip)
                    {
                        return;
                    }
                }
                return;
            }
        }
    }

    public void PlayBGM(string sound)
    {
        if (sound == soundBackgrounds.name)
        {
            audioSourceBackground.clip = soundBackgrounds.clip;
            audioSourceBackground.Play();
        }
    }

    public void StopAllSE()
    {
        for (int i = 0; i < audioSourceEffects.Length; ++i)
        {
            audioSourceEffects[i].Stop();
            audioSourceEffects[i].clip = null;
            playSoundName[i] = null;
        }
    }

    public void StopSE(string sound)
    {
        for (int i = 0; i < audioSourceEffects.Length; ++i)
        {
            if (playSoundName[i] == sound)
            {
                audioSourceEffects[i].Stop();
                audioSourceEffects[i].clip = null;
                playSoundName[i] = null;
            }
        }
    }

    public void StopBGM(string sound)
    {
        if (audioSourceBackground.isPlaying && sound == soundBackgrounds.name)
        {
            audioSourceBackground.Stop();
        }
    }
}