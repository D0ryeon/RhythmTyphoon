using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameResultManager : MonoBehaviour
{
    [SerializeField] private GameResult GameResult;

    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private TextMeshProUGUI NumberOfTimes_Perfect;
    [SerializeField] private TextMeshProUGUI NumberOfTimtes_Good;
    [SerializeField] private TextMeshProUGUI NumberOfTimtes_Miss;
    [SerializeField] private TextMeshProUGUI MaxComboText;
    [SerializeField] private TextMeshProUGUI GameClear;


    private void Start()
    {
        ScoreText.text = GameResult.FinishScore.ToString();
        NumberOfTimes_Perfect.gameObject.SetActive(true);
        NumberOfTimes_Perfect.text = GameResult.numberOfTimesPerfect.ToString();
        NumberOfTimtes_Good.gameObject.SetActive(true);
        NumberOfTimtes_Good.text = GameResult.numberOfTimesGood.ToString();
        NumberOfTimtes_Miss.gameObject.SetActive(true);
        NumberOfTimtes_Miss.text = GameResult.numberOfTimesMiss.ToString();
        MaxComboText.text =GameResult.maxCombo.ToString();
    }
}
