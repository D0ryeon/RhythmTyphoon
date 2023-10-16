using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CharacterStatusHandler : MonoBehaviour
{
    private CharacterStatusController _statusController;
    private IBaseData _playerData;

    private void Awake()
    {
        this.AddComponent<CharacterStatusController>();
        _playerData = DataBase.Instance.PlayerData;
    }

    private void Start()
    {
        _statusController.OnDamage += ChangeHP;
        _statusController.OnHeal += ChangeHP;
    }

    private void ChangeHP(int damage)
    {
        _playerData.HP += damage;
        if (_playerData.HP <= 0) 
        {
            _statusController.CallDeath();
        }
    }
}
