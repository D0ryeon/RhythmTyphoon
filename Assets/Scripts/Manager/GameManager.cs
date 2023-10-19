using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerPrefabType
{
    PlayerWalk,
    PlayerAttack
}

public enum EScene
{
    StartScene,
    SettingScene,
    SetPlayerScene,
    StoryScene,
    BattleScene,
    ClearScene,
    GameOverScene,
}


[Serializable]
public struct PlayerCreateInfo
{
    public Vector2 Pos;
    public EPlayerPrefabType prefabType;
}

public class GameManager : Singletone<GameManager>
{
    protected GameManager()
    {
    }

    private DataBase _dataBase;
    private int _eventID;
    private EScene _eNowScene;

    public Action OnRhythmModeEvent;
    public Action<int> OnEvnetIDChage;
    public int eventID { get { return _eventID; } }
    public EScene ENowScene { get { return _eNowScene; } }

    private void Awake()
    {
        _dataBase = DataBase.Instance;
    }

    private void Start()
    {
        OnEvnetIDChage += OnEvnetIDchange;
    }

    private void InstantiateGameObject(EPlayerPrefabType prefabType, Vector2 vector2)
    {
        if(prefabType.ToString() == "PlayerWalk")
        {
            Instantiate(_dataBase.PlayerWalk, vector2, Quaternion.identity);
        }
        else
        {
            Instantiate(_dataBase.PlayerAttack, vector2, Quaternion.identity);
        }
        
    }

    public void CallOnRhythmMode()
    {
        OnRhythmModeEvent?.Invoke();
    }

    public void CallOnEvenetIDchange(int value)
    {
        OnEvnetIDChage?.Invoke(value);
    }

    private void OnEvnetIDchange(int value)
    {
        _eventID = value;
    }

    //void SetSync(float addSync)
    //{

    //}
}
