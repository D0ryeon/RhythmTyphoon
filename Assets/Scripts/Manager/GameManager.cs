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
    private EScene _eNowScene;

    public Action OnRhythmModeEvent;
    public EScene ENowScene { get { return _eNowScene; } }

    private void Awake()
    {
        _dataBase = DataBase.Instance;
    }
}
