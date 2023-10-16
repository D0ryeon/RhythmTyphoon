using System;
using System.Collections;
using UnityEngine;

public class CharactersController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnMenuEvent;
    public event Action OnAttackEvent;

    protected virtual void Awake()
    {

    }

    public void CallMoveEvent(Vector2 direction)
    {
        OnMoveEvent?.Invoke(direction);
    }
    public void CallMenuEvent()
    {
        OnMenuEvent?.Invoke();
    }
    public void CallAttackEvent()
    {
        OnAttackEvent?.Invoke();
    }
}
