using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Security.Authentication.ExtendedProtection;
using TMPro;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class CreativeMode : MonoBehaviour
{
    public Pattern[] Patterns;
    public Pattern currentPattern;

    [SerializeField] private GameObject NoteSpawnManagerPrefab;
    [SerializeField] private GameObject ObjectPoolPrefab;
    [SerializeField] private GameObject AudioManagerPrefab;
    [SerializeField] private GameObject NoteEndZonePrefab;

    private NoteSpawnManager NoteSpawnManager;
    private AudioManager AudioManager;
    private ObjectPool ObjectPool;
    private NoteEndZone NoteEndZone;


    [SerializeField] private Button RecordingStart;
    [SerializeField] private Button RecordingStop;
    private bool IsRecording =false;

    [SerializeField] private Button TestCurrentPattern;

    [SerializeField] private Button StopWatch;
    [SerializeField] private TextMeshProUGUI StopWatchText;
    private float stopWatch;
    private bool IsPlaying = false;

    [SerializeField] private TextMeshProUGUI CursorToCurrentMusicText;
    private int CursorToCurrentMusic =0;

    [SerializeField] private Button MusicIndexUP;
    [SerializeField] private Button MusicIndexDown;

    [SerializeField] private Button SaveButton;
    [SerializeField] private Button ClearButton;

    [SerializeField] private Button MusicPlayButton;
    [SerializeField] private Button MusicStopButton;

    [SerializeField] private Button TestStopButton;
    [SerializeField] private Button RetryButton;

    public List<float> MusicSink = new List<float>();

    public int LeftClick = 0;
    public int RightClick = 0;
    public int TotalClick = 0;

    private void Awake()
    {
        GameObject objectPool = Instantiate(ObjectPoolPrefab);
        ObjectPool = objectPool.GetComponent<ObjectPool>();

        GameObject NoteSpawnManagerer = Instantiate(NoteSpawnManagerPrefab);
        NoteSpawnManager = NoteSpawnManagerer.GetComponent<NoteSpawnManager>();
        NoteSpawnManager.SetObjectPool(ObjectPool);

        GameObject Audiomanager = Instantiate(AudioManagerPrefab);
        AudioManager = Audiomanager.GetComponent<AudioManager>();

        GameObject NoteEndzone= Instantiate(NoteEndZonePrefab);
        NoteEndZone = NoteEndzone.GetComponent<NoteEndZone>();

    }

    private void Start()
    {
        RecordingStart.onClick.AddListener(OnPushButtonRecordingStart);
        RecordingStop.onClick.AddListener(OnPushButtonRecordingStop);

        TestCurrentPattern.onClick.AddListener(OnPushButtonTestCurrentPattern);

        MusicIndexUP.onClick.AddListener(() => UpdateCursorForMusic(1)) ;
        MusicIndexDown.onClick.AddListener(()=> UpdateCursorForMusic(-1));

        SaveButton.onClick.AddListener(() => OnPushSaveButton());

        ClearButton.onClick.AddListener(()=> OnPushClear());

        MusicPlayButton.onClick.AddListener(OnPushStartMusic);
        MusicStopButton.onClick.AddListener(OnPushStopMusic);

        TestStopButton.onClick.AddListener(()=> NoteSpawnManager.StopNoteSpawn());
        TestStopButton.onClick.AddListener(() => NoteEndZone.ClearAllNote());
        TestStopButton.onClick.AddListener(() => IsPlaying = false) ;

        RetryButton.onClick.AddListener(() => NoteSpawnManager.StopNoteSpawn());
        RetryButton.onClick.AddListener(() => NoteEndZone.ClearAllNote());
        RetryButton.onClick.AddListener(() => NoteSpawnManager.StartNoteSpawn(MusicSink[CursorToCurrentMusic]));
        RetryButton.onClick.AddListener(() => stopWatch = 0);

        StopWatch.onClick.AddListener(() => stopWatch = 0);
        StopWatch.onClick.AddListener(() => StopWatchText.text = stopWatch.ToString());

        CursorToCurrentMusicText.text = Patterns[CursorToCurrentMusic].MusicName;
    }

    private void Update()
    {
        if(IsRecording || IsPlaying)
        {
            stopWatch += Time.deltaTime;
            StopWatchText.text = stopWatch.ToString();
        }
    }
    // OnPushButton
    #region
    private void OnPushButtonRecordingStart()
    {
        stopWatch = 0;
        currentPattern.Notes.Clear();
        IsRecording = true;
        AudioManager.PlayMusic(Patterns[CursorToCurrentMusic].MusicName , 1.0f);

        LeftClick = 0;
        RightClick = 0;
        TotalClick = 0; 
    }

    private void OnPushButtonRecordingStop()
    {
        IsRecording = false;
        AudioManager.StopMusic();
        IsPlaying = false;
    }
    private void OnPushButtonTestCurrentPattern()
    {
       NoteSpawnManager.SetPattern(currentPattern);
       NoteSpawnManager.StartNoteSpawn(0);
       IsPlaying = true;
        AudioManager.PlayMusic(Patterns[CursorToCurrentMusic].MusicName, MusicSink[CursorToCurrentMusic]);
    }
    // 게임에 사용하는 채보로 저장 , Save as Pattern to used in the game
    private void OnPushSaveButton()
    {
        Patterns[CursorToCurrentMusic].Notes.Clear();
        foreach(var note in currentPattern.Notes)
        {
            Patterns[CursorToCurrentMusic].Notes.Add(note);
        }
    }
    // 선택한 게임의 채보 비우기 , Clear Pattern used in game
    private void OnPushClear()
    {
        Patterns[CursorToCurrentMusic].Notes.Clear();
    }
    private void OnPushStartMusic()
    {
        AudioManager.PlayMusic(Patterns[CursorToCurrentMusic].MusicName);
        IsPlaying = true;   
    }
    private void OnPushStopMusic()
    {
        AudioManager.StopMusic();
        IsPlaying = false;
    }

    #endregion

    // MouseInput
    #region
    void OnAttack()
    {
        if (IsRecording)
        {
            float InputTime = stopWatch;
            Pattern.Note note = new Pattern.Note();
            note.time = InputTime;
            note.type = 0;
            currentPattern.Notes.Add(note);
            LeftClick++;
        }
    }

    void OnAttack2()
    {
        if (IsRecording)
        {
            float InputTime = stopWatch;
            Pattern.Note note = new Pattern.Note();
            note.time = InputTime;
            note.type = 1;
            currentPattern.Notes.Add(note);
            RightClick++;
        }
    }
    #endregion

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
    // 화면에 남아있는 노트들 파괴 , 게임 종료 시, NoteEndZone의 콜라이더를 무식하게 확대시켰다가 축소
    private void ClearNote()
    {
        NoteEndZone.ClearAllNote();
    }
}
