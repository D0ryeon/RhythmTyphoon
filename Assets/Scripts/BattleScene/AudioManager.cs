using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Build;
using UnityEditor.Build.Content;
using UnityEngine;

[System.Serializable]
public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource;
    public AudioClip[] musicClip;
    public Dictionary<string, AudioClip> musicClips;

    private void Start()
    {
        musicClips= new Dictionary<string, AudioClip>();
        musicClips["WIND"] = musicClip[0];
        musicClips["IDOL"] = musicClip[1];
        musicClips["KICKBACK"] = musicClip[2];
    }
    public void PlayMusic(string name)
    {
        musicSource.clip = musicClips[name];
        musicSource.Play();
    }

    public void PauseMusic()
    {
        musicSource.Pause();
    }

    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    public void StopMusic()
    {
        musicSource.Stop();
    }

}
