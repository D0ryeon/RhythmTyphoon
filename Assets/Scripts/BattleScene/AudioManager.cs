using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource musicSource; // ������ ����� AudioSource

    public AudioClip mp3Music; // AudioClip ������ Inspector���� ����


    // ���� ��� �Լ�
    public void PlayMusic()
    {
        musicSource.clip = mp3Music;
        musicSource.Play();
    }

    // ���� �Ͻ� ���� �Լ�
    public void PauseMusic()
    {
        musicSource.Pause();
    }

    // ���� �ٽ� ��� �Լ�
    public void ResumeMusic()
    {
        musicSource.UnPause();
    }

    // ���� ���� �Լ�
    public void StopMusic()
    {
        musicSource.Stop();
    }

    // Start() �Լ����� ���� ���
    void Start()
    {
        Invoke(nameof(PlayMusic), 3.0f);
    }
}
