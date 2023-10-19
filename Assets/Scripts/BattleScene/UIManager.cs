using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public enum NoteState { Perfect, Good, Miss};
    public enum GameState { GameOver, GameClear, Pause};

    public int currentScore;
    public int combo;
    public int maxHealth;
    public int startHealth;
    public bool gameOver { get; private set; } = false;
    public bool gameClear { get; private set; } = false;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _comboText;
    [SerializeField] private TextMeshProUGUI _startCountText;
    [SerializeField] private TextMeshProUGUI _gameOverText;
    [SerializeField] private TextMeshProUGUI _gameClearText;

    [SerializeField] private TextMeshProUGUI _numberOfTimesPerfectText;
    [SerializeField] private TextMeshProUGUI _numberOfTimesGoodText;
    [SerializeField] private TextMeshProUGUI _numberOfTimesMissText;

    public event Action<int> OnUpdateScore;
    public event Action<int> OnUpdateCombo;
    public event Action<int> OnUpdateHealth;
    public event Action<NoteState> OnNoteDisable;
    public event Action<GameState> OnGameStateUpdate;

    [SerializeField] private NoteSpawnManager _noteSpawnManager;
    [SerializeField] private HealthSystem _healthSystem;

    private NoteEndZone NoteEndZone;

    public int numberOfTimesPerfect { get; private set; }
    public int numberOfTimesGood { get; private set; }
    public int numberOfTimesMiss { get; private set; }

    [SerializeField] private GameResult _gameResult;

  public void InitalizeUIManager()
    {
        numberOfTimesPerfect = 0;
        numberOfTimesGood = 0;
        numberOfTimesMiss = 0;

        _healthSystem.InitalizeHeart(startHealth, maxHealth);

        OnUpdateScore += (int change) => { currentScore += change; };
        OnUpdateCombo += (int change) => { combo += change; };
        OnUpdateHealth += _healthSystem.UpdateIcon;
    }
  
    public void UpdateScore(int change)
    {
        OnUpdateScore?.Invoke(change);
        _scoreText.text = currentScore.ToString();
    }

    public void UpdateCombo(int change)
    {
       OnUpdateCombo?.Invoke(change);
        //Miss, Combo reset
        if(change == -1) 
            combo = 0;
        _comboText.text = combo.ToString();
    }

    public void UpdateHealth(int change)
    {
        OnUpdateHealth?.Invoke(change);
    }

    public void UpdateStartCount(int num)
    {
        _startCountText.text = num.ToString();
        if(num== -1)
        {
            _startCountText.gameObject.SetActive(false);
        }
    }

    public void UpdateGameState(GameState gameState)
    {
        OnGameStateUpdate?.Invoke(gameState);

        switch (gameState)
        {
            case GameState.GameOver:
                _gameOverText.gameObject.SetActive(true);
                _noteSpawnManager.StopNoteSpawn();
                gameOver = true;
                gameClear = false;
                SetAcitveNumberOfTimes();
                RecordGameResult();
                break;
            case GameState.GameClear:
                if (gameOver)
                    break;
                _gameClearText.gameObject.SetActive(true);
                _noteSpawnManager.StopNoteSpawn();
                SetAcitveNumberOfTimes();
                gameClear = true;
                gameOver = false;
                RecordGameResult();
                NoteEndZone.ClearAllNote();
                break;
            case GameState.Pause: 
                break;
        }
    }

    public void UpdateNumberOfTimes(NoteState state)
    {
        OnNoteDisable?.Invoke(state);
        switch (state)
        {
            case NoteState.Perfect:
                numberOfTimesPerfect++;
                break;
            case NoteState.Good:
                numberOfTimesGood++;
                break;
            case NoteState.Miss:
                numberOfTimesMiss++;
                break;
        }
    }
    //ToDo For Check numberOfTimes
    private void SetAcitveNumberOfTimes()
    {
        _numberOfTimesPerfectText.gameObject.SetActive(true);
        _numberOfTimesPerfectText.text = numberOfTimesPerfect.ToString();
        _numberOfTimesGoodText.gameObject.SetActive(true);
        _numberOfTimesGoodText.text = numberOfTimesGood.ToString();
        _numberOfTimesMissText.gameObject.SetActive(true);
        _numberOfTimesMissText.text = numberOfTimesMiss.ToString();
    }

    public void SetNoteSpawnManager(NoteSpawnManager noteSpawnManager)=> _noteSpawnManager = noteSpawnManager;
    public void SetHealthSystem(HealthSystem healthSystem) => _healthSystem = healthSystem;

    public void SetNoteEndZone(NoteEndZone noteEndZone)=> NoteEndZone = noteEndZone;

    public void SetGameResult(GameResult gameResult)=> _gameResult = gameResult;

    private void RecordGameResult()
    {
        _gameResult.FinishScore = currentScore;
        _gameResult.numberOfTimesPerfect = numberOfTimesPerfect;
        _gameResult.numberOfTimesGood= numberOfTimesGood;
        _gameResult.numberOfTimesMiss = numberOfTimesMiss;
        _gameResult.GameClear = gameClear;
    }
}
