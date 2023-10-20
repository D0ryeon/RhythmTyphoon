using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class NoteBasic : MonoBehaviour
{
    public bool lastNote = false;

    public enum State
    {
        Default, Perfect, Good, Miss
    }
    protected State state;

    protected const string Player = "Player";
    protected const string Miss = "Miss";

    protected Rigidbody2D rb;
    protected Vector2 direction;
    protected UIManager uiManager;

    protected virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.Default;
    }

    protected virtual void FixedUpdate()
    {
        rb.velocity = direction;
    }

    public void SetDirection(Vector2 direction) => this.direction = direction;

    public void SetUIManager(UIManager uiManager) => this.uiManager = uiManager;

    // 이 밑에서 State에 따라 다른 동작을 하게 하면 됩니다. 
    protected virtual void NoteStateChange()
    {
        switch (state)
        {
            case State.Default:

                break;
            case State.Perfect:

                break;
            case State.Good:

                break;
            case State.Miss:

                break;
            default:
                break;
        }
    }


}
