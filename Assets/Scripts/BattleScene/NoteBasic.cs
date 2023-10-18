using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class NoteBasic : MonoBehaviour
{
    public bool lastNote = false;

    protected enum State
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

    // �� �ؿ��� State�� ���� �ٸ� ������ �ϰ� �ϸ� �˴ϴ�. 
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
