using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    [SerializeField] private GameObject _noteSpawnManagerPrefab;
    [SerializeField] private GameObject _uiManagerPrefab;
    [SerializeField] private GameObject _healthSystemPrefab;
    [SerializeField] private GameObject _objectPoolPrefab;
    [SerializeField] private GameObject _noteEndZonePrefab;
    [SerializeField] private GameObject _audioManagerPrefab;

    [SerializeField] private NoteSpawnManager _noteSpawnManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private HealthSystem _healthSystem;
    [SerializeField] private ObjectPool _objectPool;
    [SerializeField] private NoteEndZone _noteEndZone;
    [SerializeField] private AudioManager _audioManager;


    [SerializeField] private Pattern[] Stage;
    [SerializeField] private float[] MusicSink;
    [SerializeField] private int stageNumber =0;

    [SerializeField] private GameResult _gameResult;


    private void Awake()
    {
        GameObject noteSpawnManagerObj = Instantiate(_noteSpawnManagerPrefab);
        GameObject uiManagerObj = Instantiate(_uiManagerPrefab);
        GameObject healthSystemObj = Instantiate(_healthSystemPrefab);
        GameObject objectPoolObj = Instantiate(_objectPoolPrefab);
        GameObject noteEndZoneObj = Instantiate(_noteEndZonePrefab);
        GameObject audioManagerObj = Instantiate(_audioManagerPrefab);

        _noteSpawnManager= noteSpawnManagerObj.GetComponent<NoteSpawnManager>();
        _uiManager = uiManagerObj.GetComponent<UIManager>();
        _healthSystem = healthSystemObj.GetComponent<HealthSystem>();
        _objectPool = objectPoolObj.GetComponent<ObjectPool>();
        _audioManager = audioManagerObj.GetComponent<AudioManager>();
        _noteEndZone = noteEndZoneObj.GetComponent<NoteEndZone>();

        _noteSpawnManager.SetUIManager(_uiManager);
        _noteSpawnManager.SetObjectPool(_objectPool);

        _healthSystem.SetUIManager(_uiManager);

        _uiManager.SetHealthSystem(_healthSystem);
        _uiManager.SetNoteSpawnManager(_noteSpawnManager);
        _uiManager.SetNoteEndZone(_noteEndZone);
        _uiManager.InitalizeUIManager();
        _uiManager.SetGameResult(_gameResult);
        _uiManager.SetAudioManger(_audioManager);
    }

    private void Start()
    {
        _audioManager.PlayMusic(Stage[stageNumber].MusicName, MusicSink[stageNumber]);

        _noteSpawnManager.SetPattern(Stage[stageNumber]);
        _noteSpawnManager.StartNoteSpawn(0);

    }


    // Use This Method to choice Stage
    public void SetStage(int stageNumber)
    {
        this.stageNumber = stageNumber;
    }
}
