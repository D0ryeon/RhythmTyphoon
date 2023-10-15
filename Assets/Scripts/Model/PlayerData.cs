using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[Serializable]
public class PlayerData : IBaseData
{
    [SerializeField] private string _playerName;
    [SerializeField] private int _maxHP;
    [SerializeField] private float _speed;
    private int _hp;

    public string Name { get { return _playerName; } }
    public int HP { get { return _hp; } set { _hp = value; } }
    public int MaxHP { get { return _maxHP; } }
    public float Speed { get { return _speed; } }

}
