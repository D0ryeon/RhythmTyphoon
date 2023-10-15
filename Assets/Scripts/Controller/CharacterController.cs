using System;
using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;
    public event Action OnMenuEvent;
    public event Action OnInteractionEvent;

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
    public void CallInteractionEvent()
    {
        OnInteractionEvent?.Invoke();
    }
    

}
