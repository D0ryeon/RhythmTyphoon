using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singletone<UIManager> 
{ 
    private int score;
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
        StartCoroutine(nameof(StartCount));
    }

    public void UpdateScore(int change)
    {

    }

    public void UpdateCombo(int change)
    {

    }

    public void UpdateHealth(int change)
    {

    }

 
    private IEnumerator StartCount()
    {
        _startCountText.text = "3";
        yield return new WaitForSeconds(1f);
        _startCountText.text = "2";
        yield return new WaitForSeconds(1f);
        _startCountText.text = "1";
        yield return new WaitForSeconds(1f);
        _startCountText.text = "0";
        yield return new WaitForSeconds(0.2f);
    }
 
}
