using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterStatusController : MonoBehaviour
{
    private CharacterStatusController _statusController;
    private IBaseData _data;

    public event Action<int> OnDamage;
    public event Action<int> OnHeal;
    public event Action OnDeath;

    private void Awake()
    {
        _statusController = GetComponent<CharacterStatusController>();
        if (gameObject.tag == "Player")
        {
            _data = DataBase.Instance.PlayerData;
        }
        else
        {
            Debug.Log("Tag를 제대로 설정해 주세요.");
        }
    }

    public void ChangeHealth(int change)
    {
        _data.HP = _data.HP + change > _data.MaxHP ? _data.MaxHP : _data.HP + change;
        if (_data.HP >= 0)
        {
            OnHeal?.Invoke(change);
        }
        else
        {
            OnDamage?.Invoke(change);
        }

        if(_data.HP == 0)
        {
            CallDeath();
        }
    }

    public void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
