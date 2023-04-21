using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
public class SoundsManager : Singleton<SoundsManager>
{
    public AudioSource soundsMusic;
    public List<AudioSource> sfxMusic = new List<AudioSource>();
    public AudioMixer audioMixer;

    public void PlaySoundsVolume(string name)
    {
        for(int i = 0; i < sfxMusic.Count; i++)
        {
            if (sfxMusic[i].name == name)
            {
                sfxMusic[i].Play();
            }
        }
    }
    public void StopSoundsVolume(string name)
    {
        for (int i = 0; i < sfxMusic.Count; i++)
        {
            if (sfxMusic[i].name == name)
            {
                sfxMusic[i].Stop();
            }
        }
    }
    public void SoundsMusic()
    {
        soundsMusic.Play();
    }

    public void AudiMixer(string name,float volume)
    {
        audioMixer.GetFloat(name, out volume);
    }
}
