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

    [Header("�׽�Ʈ�� bool")]
    public bool test_PlaySound;
    public bool test_StopSound;
    
    //�߰�
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

    //����
    private void Start()
    {
        // ������ ����, �÷��̾� ����, ����Ʈ ���� �ʱ�ȭ
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        playerVolumeSlider.value = PlayerPrefs.GetFloat("PlayerVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);

        // Resources �������� MP3 ������ �ε��Ͽ� AudioClip�� �Ҵ�
        AudioClip backgroundAudioClip = Resources.Load<AudioClip>("BackGroundTest");
        AudioClip effectAudioClip = Resources.Load<AudioClip>("EffectTest");
        AudioClip playerAudioClip = Resources.Load<AudioClip>("PlayerWalkTest");

        // ����� ����� �ҽ��� AudioClip �Ҵ�
        backgroundAudioSource.clip = backgroundAudioClip;
        playerAudioSource.clip = playerAudioClip;
        effectAudioSource.clip= effectAudioClip;

        // ���� ������ ������Ʈ
        //UpdateVolumes();
    }

    public void SetMasterVolume(float volume)
    {
        // ������ ���� ����
        masterVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);

        // ����� ���� ����
        backgroundAudioSource.volume = volume;
        Debug.Log("Master Volume: " + volume);

        // �÷��̾� ���� ����
        playerAudioSource.volume = volume;
        Debug.Log("Player Volume: " + volume);

        // ����Ʈ ���� ����
        effectAudioSource.volume = volume;
        Debug.Log("Effect Volume: " + volume);

        PlayerPrefs.Save();
    }

    public void SetPlayerVolume(float volume)
    {
        // �÷��̾� ���� ����
        playerAudioSource.volume = volume;
        PlayerPrefs.SetFloat("PlayerVolume", volume);
        PlayerPrefs.Save();
    }

    public void SetEffectVolume(float volume)
    {
        // ����Ʈ ���� ����
        effectAudioSource.volume = volume;
        PlayerPrefs.SetFloat("EffectVolume", volume);
        PlayerPrefs.Save();
    }

    public void UpdateVolumes()
    {
        //������, �÷��̾�, ����Ʈ ������ ������Ʈ
        SetMasterVolume(masterVolumeSlider.value);
        SetPlayerVolume(playerVolumeSlider.value);
        SetEffectVolume(effectVolumeSlider.value);
    }






    // �߰�~~
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









