using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : Singletone<DataBase>
{
    protected DataBase()
    {
    }
    private GameObject _playerWalk;
    private GameObject _playerAttack;
    private PlayerData _playerData;

    private GameManager _gameManager;


    public PlayerData PlayerData 
    { 
        get 
        { 
            if(_playerData == null)
            {
                _playerData = new PlayerData(name: "Test", maxhp: 100, speed: 5);
            }
            return _playerData; 
        }
    }

    public GameObject PlayerWalk { get { return _playerWalk; } }
    public GameObject PlayerAttack { get { return _playerAttack; } }

    private void Awake()
    {
        _gameManager = GameManager.Instance;
        _playerWalk = Resources.Load<GameObject>("Prefabs/Player/PlayerWalk");
        _playerAttack = Resources.Load<GameObject>("Prefabs/Player/PlayerAttack");
    }

    public void SetPlayerData(string name, int maxhp, int speed)
    {
        _playerData = new PlayerData(name, maxhp, speed);
    }
}
