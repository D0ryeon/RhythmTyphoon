using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterStatusController : MonoBehaviour
{
    private CharacterStatusController _statusController;
    private IBaseData _data;

    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;

    private void Awake()
    {
        _statusController = GetComponent<CharacterStatusController>();
        if (gameObject.tag == "Player")
        {
            _data = DataBase.instance.PlayerData;
        }
        else
        {
            Debug.Log("Tag를 제대로 설정해 주세요.");
        }
    }

    public void ChangeHealth(int change)
    {
        int hp = _data.HP;
        hp += change;
        if (change > 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
        }

        if (hp <= 0)
        {
            OnDeath?.Invoke();
        }
    }
}
