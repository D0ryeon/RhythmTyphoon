using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{ 
    private int currentScore;
    private int combo;
    private int maxHealth;
    private int currentHealth;


    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _comboText;

    [SerializeField] private TextMeshProUGUI _startCountText;



    public event Action<int> OnUpdateScore;
    public event Action<int> OnUpdateCombo;
    public event Action<int> OnUpdateHealth;

    [SerializeField] private NoteSpawnManager noteSpawnManager;

    private void Start()
    {
        currentScore = 0;
        combo = 0;
        maxHealth = 5;
        OnUpdateScore += (int change) => { currentScore += change; };
        OnUpdateCombo += (int change) => { combo += change; };
        OnUpdateHealth += (int change) => { currentHealth += change; };
    }

  
    public void UpdateScore(int change)
    {
        OnUpdateScore?.Invoke(change);
        _scoreText.text = currentScore.ToString();
    }

    public void UpdateCombo(int change)
    {
       OnUpdateCombo?.Invoke(change);
        _comboText.text = combo.ToString();
    }

    public void UpdateHealth(int change)
    {
        OnUpdateHealth?.Invoke(change);
    }
 
}
