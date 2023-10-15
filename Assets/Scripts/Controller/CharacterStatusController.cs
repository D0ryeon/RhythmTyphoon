using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class CharacterStatusController : MonoBehaviour
{
    public event Action OnDamage;
    public event Action OnHeal;
    public event Action OnDeath;

    private int _hp;

    private void Start()
    {
        _hp = GetComponent<IBaseData>().HP;
    }

    public bool ChangeHealth(int change)
    {
        if(change > 0)
        {
            OnHeal?.Invoke();
        }
        else
        {
            OnDamage?.Invoke();
        }
        return true;
    }

    private void CallDeath()
    {
        OnDeath?.Invoke();
    }
}
