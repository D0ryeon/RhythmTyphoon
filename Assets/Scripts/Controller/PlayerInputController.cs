using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharactersController
{
    private Camera _camera;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnMenu()
    {
        CallMenuEvent();
    }

    public void OnAttack()
    {
        CallAttackEvent();
    }
    
    public void OnAction()
    {
        Debug.Log("test");
        CallInteractionEvent();
    }
}
