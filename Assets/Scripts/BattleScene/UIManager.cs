using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singletone<UIManager> 
{ 
    private int currentScore;
    private int combo;
    private int maxHealth;
    private int currentHealth;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _comboText;

    [SerializeField] private TextMeshProUGUI _startCountText;

    [SerializeField] private GameObject _healthPrefab;
    private GameObject[] HealthIcons;

    public event Action<int> OnUpdateScore;
    public event Action<int> OnUpdateCombo;
    public event Action<int> OnUpdateHealth;

    private NoteSpawnManager noteSpawnManager;

    private void Start()
    {
        noteSpawnManager = NoteSpawnManager.instance;
        currentScore = 0;
        combo = 0;
        maxHealth = 5;
        OnUpdateScore += (int change) => { currentScore += change; };
        OnUpdateCombo += (int change) => { combo += change; };
        OnUpdateHealth += (int change) => { currentHealth += change; };

    }

    private void UIManager_OnUpdateHealth(int obj)
    {
        throw new NotImplementedException();
    }

    public void UpdateScore(int change)
    {
        OnUpdateScore?.Invoke(change);
        Debug.Log("CurrentScore : "+currentScore);
    }

    public void UpdateCombo(int change)
    {
       OnUpdateCombo?.Invoke(change);
        Debug.Log("Combo : " + combo);
    }

    public void UpdateHealth(int change)
    {
        OnUpdateHealth?.Invoke(change);
    }

 
}
