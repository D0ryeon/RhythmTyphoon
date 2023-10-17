using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;
using static Pattern;

public class CreativeMode : MonoBehaviour
{
    public enum EventPattern { Trap, Special1, Special2, Special3 }
    public struct EventData
    {
        public float indexTiming;
        public EventPattern eventPattern;
    }

    public Pattern[] Patterns;

    public Pattern currentPattern;

    
    private float InputTiming1;
    private float InputTiming2;
    private float InputTiming3;

    private float SpecialInputTiming1;
    private float SpecialInputTiming2;
    private float SpecialInputTiming3;

    public float musicSink;

    public bool recording = false;

    public List<float> InputTiming;
    public List<float> SpecialInputTiming;
    public float currentTime;

    public List<float> TestTiming;

    [SerializeField] private TestNoteSpawn TestNoteSpawn;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] private TestPlayer testPlayer;

    private void Start()
    {
        currentTime = 0;

        InputTiming1 = 0;
        InputTiming2 = 0;
        InputTiming3 = 0;
      
    }

    private void Update()
    {
        if(recording)
         currentTime += Time.deltaTime;
    }

    public void OnMouseRight()
    {
        SpecialInputTiming2 = currentTime;
        SpecialInputTiming3 = SpecialInputTiming2 - SpecialInputTiming1;

        float SpecialRoundedValue = Mathf.Round(SpecialInputTiming3 * 100.0f) * 0.01f;

        SpecialInputTiming.Add(SpecialRoundedValue);
        SpecialInputTiming1 = SpecialInputTiming2;
    }
    public void OnMouseLeft()
    {
        InputTiming2 = currentTime;
        InputTiming3 = InputTiming2 - InputTiming1;

        float roundedValue = Mathf.Round(InputTiming3 * 100.0f) * 0.01f;

        InputTiming.Add(roundedValue);
        InputTiming1 = InputTiming2;
    }

    public void RecordingStart()
    {
        InputTiming.Clear();
        SpecialInputTiming.Clear();
        Invoke(nameof(musicStart), 1.0f);
        recording = true;
    }

    public void musicStart()
    {
        AudioManager.StopMusic();
        AudioManager.PlayMusic();
    }

    public void GameStart()
    {
        TestNoteSpawn.StartGame();

    }

    public void PauesGame()
    {
        AudioManager.PauseMusic();
        TestNoteSpawn.PauseCorutine();
    }
    public void Save()
    {
      
    }
}
