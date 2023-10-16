using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneManager : MonoBehaviour
{
    [SerializeField] private NoteSpawnManager _noteSpawnManager;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private HealthSystem _healthSystem;

    private void Start()
    {
        NoteSpawnManager noteSpawnManager = Instantiate(_noteSpawnManager);
        UIManager uiManager = Instantiate(_uiManager);
        HealthSystem healthSystem = Instantiate(_healthSystem);

        noteSpawnManager.SetUIManager(uiManager);
        healthSystem.SetUIManager(uiManager);

        uiManager.SetHealthSystem(healthSystem);
        uiManager.SetNoteSpawnManager(noteSpawnManager);
        uiManager.InitalizeUIManager();
        noteSpawnManager.StartGame();
    }
}
