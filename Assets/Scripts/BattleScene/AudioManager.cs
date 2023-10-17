using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource; // 음악을 재생할 AudioSource

    public AudioClip mp3Music; // AudioClip 변수를 Inspector에서 설정


    // 음악 재생 함수
    public void PlayMusic()
    {
        musicSource.clip = mp3Music;
        musicSource.Play();
    }

    // 음악 일시 정지 함수
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    // 음악 다시 재생 함수
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    // 음악 정지 함수
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Start() 함수에서 음악 재생
    void Start()
    {
        Invoke(nameof(PlayMusic), 3.0f);
    }
}
