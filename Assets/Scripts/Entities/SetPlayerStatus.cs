using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public enum EGameDifficulty
{
    Normal,
    Hard,
    HardCore
}

public class SetPlayerStatus : MonoBehaviour
{
    [SerializeField] private TMP_InputField _inputField;
    private string _playerName;
    private EGameDifficulty _difficulty;
    private int _maxHP;

    public void SetPlayerName()
    {
        _playerName = _inputField.text;
    }

    public void SetGmaeDifficulty(EGameDifficulty value)
    {
        _difficulty = value;
        SetMaxHP();
    }

    private void SetMaxHP()
    {
        switch (_difficulty)
        {
            case EGameDifficulty.Normal:
                _maxHP = 5;
                break;
            case EGameDifficulty.Hard:
                _maxHP = 3;
                break;
            case EGameDifficulty.HardCore:
                _maxHP = 1;
                break;
        }
        
    }

    public void SetPlayerData()
    {
        DataBase.Instance.SetPlayerData(name: _playerName, maxhp: _maxHP, speed: 5);
    }
}
