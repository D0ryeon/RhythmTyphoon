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

    private void Awake()
    {
        musicClips= new Dictionary<string, AudioClip>();
        musicClips["WIND"] = musicClip[0];
        musicClips["IDOL"] = musicClip[1];
        musicClips["KICKBACK"] = musicClip[2];
    }
    public void PlayMusic(string name , float musicSink)
    {
        Debug.Log(name);
        if (musicClips.ContainsKey(name))
        {
            musicSource.clip = musicClips[name];
            Invoke(nameof(PlayMusicDirect), musicSink);
        }
        else
        {
            Debug.Log($"{name} 이라는 제목의 곡은 존재하지 않습니다.");
        } 
    }

    public void PlayMusic(string name)
    {
        Debug.Log(name);
        musicSource.clip = musicClips[name];
       PlayMusicDirect();
    }
    public void PlayMusicDirect()
    {
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
