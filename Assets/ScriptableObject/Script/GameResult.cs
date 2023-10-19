using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameResult", menuName = "Pattern/ScriptableObject/GameResult", order = 1)]

public class GameResult : ScriptableObject
{
    public bool GameClear;
    public int FinishScore;
    public int numberOfTimesPerfect;
    public int numberOfTimesGood;
    public int numberOfTimesMiss;
}
