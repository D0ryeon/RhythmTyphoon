using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerStatusHandler : MonoBehaviour
{
    private CharacterStatusController _statusController;
    private IBaseData _playerData;
    private HealthSystem _healthSystem;

    private void Awake()
    {
        _statusController = GetComponent<CharacterStatusController>();
        _playerData = DataBase.Instance.PlayerData;
        _healthSystem = GetComponent<HealthSystem>();
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
