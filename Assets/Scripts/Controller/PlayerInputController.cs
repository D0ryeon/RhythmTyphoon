using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : CharacterController
{
    private Camera _camera;

    protected override void Awake()
    {
        base.Awake();
        _camera = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Debug.Log("OnMove");
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnMenu()
    {
        Debug.Log("OnMenu");
        CallMenuEvent();
    }

    public void OnInteraction()
    {
        Debug.Log("OnInteraction");
        CallInteractionEvent();
    }
    
}
