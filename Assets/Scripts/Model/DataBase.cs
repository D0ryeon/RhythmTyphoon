using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : Singletone<DataBase>
{
    private PlayerData _playerData;

    public PlayerData PlayerData 
    { 
        get 
        { 
            if(_playerData == null)
            {
                _playerData = new PlayerData(name: "EE", maxhp: 100, speed: 10);
            }
            return _playerData; 
        }
    }

    public void SetPlayerData(string name, int maxhp, int speed)
    {
        _playerData = new PlayerData(name, maxhp, speed);
    }
}
