using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EPlayerPrefabType
{
    PlayerWalk,
    PlayerAttack
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

    [Header("테스트를 위한 변수")]
    public bool testMond = false;
    public string userName;
    public int maxHP;
    public int speed;
    //[Range(-0.5f, 0.5f)] public float defaultSync;
    public List<PlayerCreateInfo> playerCreateInfos;

    public Action OnRhythmModeEvent;

    private DataBase _dataBase;
    private UIManager_Test _uiManager_Test;

    private void Awake()
    {
        _dataBase = DataBase.Instance;
        _uiManager_Test = UIManager_Test.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        if(testMond)
        {
            if(userName != null && maxHP != 0 && speed != 0)
                _dataBase.SetPlayerData(userName, maxHP, speed);

            int num = playerCreateInfos.Count;
            for (int i = 0; i < num; i++)
            {
                InstantiateGameObject(playerCreateInfos[i].prefabType, playerCreateInfos[i].Pos);
            }
            testMond = false;
        }
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


    //void SetSync(float addSync)
    //{

    //}
}
