using System;
using System.Threading.Tasks.Sources;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static UnityEngine.Rendering.DebugUI;

public enum ESliderType
{
    masterVolumeSlider,
    playerVolumeSlider,
    effectVolumeSlider
}

public class SoundManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider playerVolumeSlider;
    public Slider effectVolumeSlider;

    public AudioSource backgroundAudioSource;
    public AudioSource playerAudioSource;
    public AudioSource effectAudioSource;

    [Header("테스트용 bool")]
    public bool test_PlaySound;
    public bool test_StopSound;
    
    //추가
    private void Awake()
    {
        masterVolumeSlider.onValueChanged.AddListener(
            (value) =>  
            { 
                VolumesChange
                (
                    value, 
                    new AudioSource[]{ backgroundAudioSource, playerAudioSource, effectAudioSource }
                ); 
            });
        playerVolumeSlider.onValueChanged.AddListener((value) => { VolumesChange( value, playerAudioSource); });
        effectVolumeSlider.onValueChanged.AddListener((value) => { VolumesChange(value, effectAudioSource); });
    }

    //수정
    private void Start()
    {
        // 마스터 볼륨, 플레이어 볼륨, 이펙트 볼륨 초기화
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        playerVolumeSlider.value = PlayerPrefs.GetFloat("PlayerVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);

        // Resources 폴더에서 MP3 파일을 로드하여 AudioClip에 할당
        AudioClip backgroundAudioClip = Resources.Load<AudioClip>("BackGroundTest");
        AudioClip effectAudioClip = Resources.Load<AudioClip>("EffectTest");
        AudioClip playerAudioClip = Resources.Load<AudioClip>("PlayerWalkTest");

        // 배경음 오디오 소스에 AudioClip 할당
        backgroundAudioSource.clip = backgroundAudioClip;
        playerAudioSource.clip = playerAudioClip;
        effectAudioSource.clip= effectAudioClip;

        // 볼륨 설정을 업데이트
        //UpdateVolumes();
    }

    public void SetMasterVolume(float volume)
    {
        // 마스터 볼륨 설정
        masterVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);

        // 배경음 볼륨 설정
        backgroundAudioSource.volume = volume;
        Debug.Log("Master Volume: " + volume);

        // 플레이어 볼륨 설정
        playerAudioSource.volume = volume;
        Debug.Log("Player Volume: " + volume);

        // 이펙트 볼륨 설정
        effectAudioSource.volume = volume;
        Debug.Log("Effect Volume: " + volume);

        PlayerPrefs.Save();
    }

    public void SetPlayerVolume(float volume)
    {
        // 플레이어 볼륨 설정
        playerAudioSource.volume = volume;
        PlayerPrefs.SetFloat("PlayerVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetEffectVolume(float volume)
    {
        // 이펙트 볼륨 설정
        effectAudioSource.volume = volume;
        PlayerPrefs.SetFloat("EffectVolume", volume);
        PlayerPrefs.Save();
    }

    public void UpdateVolumes()
    {
        //마스터, 플레이어, 이펙트 볼륨을 업데이트
        SetMasterVolume(masterVolumeSlider.value);
        SetPlayerVolume(playerVolumeSlider.value);
        SetEffectVolume(effectVolumeSlider.value);
    }






    // 추가~~
    private void Update()
    {
        if (test_PlaySound)
        {
            test_PlaySound = false;
            PlaySound(
            new AudioSource[] { backgroundAudioSource, playerAudioSource, effectAudioSource }
            );
        }
        
        if(test_StopSound)
        {
            test_StopSound = false;
            StopSound(
            new AudioSource[] { backgroundAudioSource, playerAudioSource, effectAudioSource }
            );
        }
    }

    private void VolumesChange(float value, AudioSource audioSource)
    {
        Debug.Log(value);
        audioSource.volume = value;
    }

    private void VolumesChange(float value, AudioSource[] audioSources)
    {
        Debug.Log(value);
        foreach(AudioSource audioSource in audioSources)
        {
            audioSource.volume = value;
        }
    }

    private void PlaySound(AudioSource audioSource)
    {
        audioSource.Play();
    }

    private void PlaySound(AudioSource[] audioSources)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Play();
        }
    }

    private void StopSound(AudioSource audioSource)
    {
        audioSource.Stop();
    }

    private void StopSound(AudioSource[] audioSources)
    {
        foreach (AudioSource audioSource in audioSources)
        {
            audioSource.Stop();
        }
    }
}









