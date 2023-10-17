using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TrapNote : MonoBehaviour
{
    enum State
    {
        Default, Perfect, Good, Miss
    }
    State state;

    private const string Player = "Player";
    private const string Miss = "Miss";

    private Rigidbody2D rb;
    private Vector2 direction;
    private UIManager uiManager;

    public bool lastNote = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        state = State.Default;
        NoteStateChange();
    }

    private void Update()
    {
        if (uiManager != null && uiManager.gameOver)
        {
            this.gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Player))
        {
            Player player = collision.GetComponent<Player>();
            if (player.movingToHitPosition)
            {
                if (uiManager != null)
                {
                    uiManager.UpdateCombo(-1);
                    uiManager.UpdateHealth(-1);
                }
                state = State.Miss;
                NoteStateChange();
            }
            else
            {
                return;
            }
        }
        else if (collision.CompareTag(Miss))
        {
            Debug.Log("Nice!");
        }

        this.gameObject.SetActive(false);
    }

    public void SetDirection(Vector2 direction) => this.direction = direction;

    public void SetUIManager(UIManager uiManager) => this.uiManager = uiManager;


    // 이 밑에서 State에 따라 다른 동작을 하게 하면 됩니다. 
    private void NoteStateChange()
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
