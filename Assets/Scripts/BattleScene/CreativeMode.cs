using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Authentication.ExtendedProtection;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using static Pattern;

public class CreativeMode : MonoBehaviour
{
    public Pattern[] Patterns;
    public Pattern currentPattern;

    [SerializeField] private GameObject TestNoteSpawnPrefab;
    [SerializeField] private TestNoteSpawn TestNoteSpawn;
    [SerializeField] private AudioManager AudioManager;
    [SerializeField] private ObjectPool ObjectPool;


    [SerializeField] private Button RecordingStart;
    [SerializeField] private Button RecordingStop;
    public bool IsRecording =false;

    [SerializeField] private Button TestCurrentPattern;
    private float stopWatch;

    [SerializeField] private TextMeshProUGUI CursorToCurrentMusicText;
    private int CursorToCurrentMusic =0;

    [SerializeField] private Button MusicIndexUP;
    [SerializeField] private Button MusicIndexDown;

    [SerializeField] private Button SaveButton;
    [SerializeField] private Button ClearButton;


    private void Awake()
    {
        GameObject NoteSpawn = Instantiate(TestNoteSpawnPrefab);
        TestNoteSpawn = NoteSpawn.GetComponent<TestNoteSpawn>(); 
        TestNoteSpawn.SetObjectPool(ObjectPool);
    }
    private void Start()
    {
        RecordingStart.onClick.AddListener(OnPushButtonRecordingStart);
        RecordingStop.onClick.AddListener(OnPushButtonRecordingStop);
        TestCurrentPattern.onClick.AddListener(OnPushButtonTestCurrentPattern);

        MusicIndexUP.onClick.AddListener(() => UpdateCursorForMusic(1)) ;
        MusicIndexDown.onClick.AddListener(()=> UpdateCursorForMusic(-1));

        SaveButton.onClick.AddListener(() => SavePatternToOriginal());

        ClearButton.onClick.AddListener(()=> ClearNotesInPrefab()); 

        CursorToCurrentMusicText.text = Patterns[CursorToCurrentMusic].MusicName;
    }

    private void Update()
    {
        if(IsRecording)
        {
            stopWatch += Time.deltaTime;
        }
    }
    private void OnPushButtonRecordingStart()
    {
        stopWatch = 0;
        currentPattern.Notes.Clear();
        IsRecording = true;
    }

    private void OnPushButtonRecordingStop()
    {
        IsRecording = false;
    }
    private void OnPushButtonTestCurrentPattern()
    {
       TestNoteSpawn.SetPattern(currentPattern);
        TestNoteSpawn.StartNoteSpawn();
    }

    void OnAttack()
    {
        float InputTime = stopWatch;
        Pattern.Note note = new Pattern.Note();
        note.time = InputTime;
        note.type = 0;
        currentPattern.Notes.Add(note);
    }

    void OnAttack2()
    {
        float InputTime = stopWatch;
        Pattern.Note note = new Pattern.Note();
        note.time = InputTime;
        note.type = 1;
        currentPattern.Notes.Add(note);
    }

    private void UpdateCursorForMusic(int num)
    {
        CursorToCurrentMusic += num;
        if(CursorToCurrentMusic >= Patterns.Length)
        {
            CursorToCurrentMusic = 0;
        }
        if(CursorToCurrentMusic < 0)
        {
            CursorToCurrentMusic = Patterns.Length - 1;
        }
        CursorToCurrentMusicText.text = Patterns[CursorToCurrentMusic].MusicName;
    }

    private void SavePatternToOriginal()
    {
        Patterns[CursorToCurrentMusic].Notes.Clear();
        foreach(var note in currentPattern.Notes)
        {
            Patterns[CursorToCurrentMusic].Notes.Add(note);
        }
    }

    private void ClearNotesInPrefab()
    {
        Patterns[CursorToCurrentMusic].Notes.Clear();
    }
}
