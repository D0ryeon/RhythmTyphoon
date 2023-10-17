using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public int currentScore;
    public int combo;
    public int maxHealth;
    public int startHealth;
    public bool gameOver { get; private set; } = false;

    [SerializeField] private TextMeshProUGUI _scoreText;
    [SerializeField] private TextMeshProUGUI _comboText;
    [SerializeField] private TextMeshProUGUI _startCountText;
    [SerializeField] private TextMeshProUGUI _gameOverText;

    public event Action<int> OnUpdateScore;
    public event Action<int> OnUpdateCombo;
    public event Action<int> OnUpdateHealth;

    [SerializeField] private NoteSpawnManager _noteSpawnManager;
    [SerializeField] private HealthSystem _healthSystem;

   private void Start()
   {
        _healthSystem.InitalizeHeart(startHealth, maxHealth);

        OnUpdateScore += (int change) => { currentScore += change; };
        OnUpdateCombo += (int change) => { combo += change; };
        OnUpdateHealth += _healthSystem.UpdateIcon;
        OnUpdateHealth += UpdateGameOver;
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

    public void UpdateStartCount(int num)
    {
        _startCountText.text = num.ToString();
        if(num== -1)
        {
            _startCountText.gameObject.SetActive(false);
        }
    }

    public void UpdateGameOver(int num)
    {
        if (_healthSystem.gameOver)
        {
            _gameOverText.gameObject.SetActive(true);
            _noteSpawnManager.StopNoteSpawnCoroutine();
            gameOver = true;
        }
    }
 
}
