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

    [SerializeField] private TextMeshProUGUI GameClear;


    private void Start()
    {
        ScoreText.text = GameResult.FinishScore.ToString();
        NumberOfTimes_Perfect.text = GameResult.numberOfTimesPerfect.ToString();
        NumberOfTimtes_Good.text = GameResult.numberOfTimesGood.ToString();
        NumberOfTimtes_Miss.text = GameResult.numberOfTimesMiss.ToString();

        if (GameResult.GameClear)
        {
            GameClear.text = "Game Clear!";
        }
        else
        {
            GameClear.text = "Game Over";
        }
    }
}
