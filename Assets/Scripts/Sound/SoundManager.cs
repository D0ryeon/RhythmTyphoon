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

        // ���� ������ ������Ʈ
        UpdateVolumes();
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
        // ������, �÷��̾�, ����Ʈ ������ ������Ʈ
        SetMasterVolume(masterVolumeSlider.value);
        SetPlayerVolume(playerVolumeSlider.value);
        SetEffectVolume(effectVolumeSlider.value);
    }
}









