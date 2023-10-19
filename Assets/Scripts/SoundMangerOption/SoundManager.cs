using System;
using UnityEngine;
using UnityEngine.UI;

public class SoundManager : MonoBehaviour
{
    public Slider masterVolumeSlider;
    public Slider playerVolumeSlider;
    public Slider effectVolumeSlider;

    public AudioSource backgroundAudioSource;
    public AudioSource playerAudioSource;
    public AudioSource effectAudioSource;

    public event Action OnPlayPlayerSound;
    public event Action OnPlayEffectSound;
    public event Action OnStopPlayerSound;
    public event Action OnStopEffectSound;

    private void Awake()
    {
        masterVolumeSlider.onValueChanged.AddListener(value => SetMasterVolume(value));
        playerVolumeSlider.onValueChanged.AddListener(value => SetPlayerVolume(value));
        effectVolumeSlider.onValueChanged.AddListener(value => SetEffectVolume(value));
    }

    private void Start()
    {
        masterVolumeSlider.value = PlayerPrefs.GetFloat("MasterVolume", 1.0f);
        playerVolumeSlider.value = PlayerPrefs.GetFloat("PlayerVolume", 1.0f);
        effectVolumeSlider.value = PlayerPrefs.GetFloat("EffectVolume", 1.0f);

        backgroundAudioSource.clip = Resources.Load<AudioClip>("BackGroundTest");
        playerAudioSource.clip = Resources.Load<AudioClip>("PlayerWalkTest");
        effectAudioSource.clip = Resources.Load<AudioClip>("EffectTest");

        backgroundAudioSource.Play();

        UpdateVolumes();
    }

    public void SetMasterVolume(float volume)
    {
        masterVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("MasterVolume", volume);
        PlayerPrefs.Save();

        UpdateVolumes();

        Debug.Log("Master Volume: " + volume);
    }

    public void SetPlayerVolume(float volume)
    {
        playerVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("PlayerVolume", volume);
        PlayerPrefs.Save();

        UpdatePlayerVolume();

        Debug.Log("Player Volume: " + volume);
    }

    public void SetEffectVolume(float volume)
    {
        effectVolumeSlider.value = volume;
        PlayerPrefs.SetFloat("EffectVolume", volume);
        PlayerPrefs.Save();

        UpdateEffectVolume();

        Debug.Log("Effect Volume: " + volume);
    }

    public void UpdateVolumes()
    {
        backgroundAudioSource.volume = masterVolumeSlider.value;
        playerAudioSource.volume = masterVolumeSlider.value;
        effectAudioSource.volume = masterVolumeSlider.value;

        OnPlayPlayerSound?.Invoke();
        OnPlayEffectSound?.Invoke();
    }

    public void UpdatePlayerVolume()
    {
        playerAudioSource.volume = playerVolumeSlider.value;
        OnPlayPlayerSound?.Invoke();
    }

    public void UpdateEffectVolume()
    {
        effectAudioSource.volume = effectVolumeSlider.value;
        OnPlayEffectSound?.Invoke();
    }
}










