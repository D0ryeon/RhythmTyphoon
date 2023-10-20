using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Note : NoteBasic
{

    [SerializeField] private float _goodRange;
    [SerializeField] private float _perfectRange;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();

        if (_perfectRange == 0)
            _perfectRange = 0.1f;

    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(Player))
        {
            Vector2 collisionPoint = collision.ClosestPoint(transform.position);
            float xDistanceFromCollisionPoint = Mathf.Abs(collisionPoint.x - this.transform.position.x);

            if (xDistanceFromCollisionPoint < _perfectRange)
            {
                state = State.Perfect;
                NoteStateChange();
            }
            else
            {
                state = State.Good;
                NoteStateChange();
            }
        }
        else if (collision.CompareTag(Miss))
        {
            state = State.Miss;
            NoteStateChange();
        }

        if (lastNote && uiManager != null)
        {
            uiManager.UpdateGameState(UIManager.GameState.GameClear);
        }
        this.gameObject.SetActive(false);
    }

    // 이 밑에서 State에 따라 다른 동작을 하게 하면 됩니다. 
    protected override void NoteStateChange()
    {
        if (uiManager != null)
        {
            switch (state)
            {
                case State.Default:
                    break;
                case State.Perfect:
                    Debug.Log("Perfect!");
                    uiManager.SetActiveNoteResult(state);
                    uiManager.UpdateScore(100);
                    uiManager.UpdateCombo(1);
                    uiManager.UpdateNumberOfTimes(UIManager.NoteState.Perfect);

                    break;
                case State.Good:
                    Debug.Log("Good");
                    uiManager.SetActiveNoteResult(state);
                    uiManager.UpdateScore(50);
                    uiManager.UpdateCombo(1);
                    uiManager.UpdateNumberOfTimes(UIManager.NoteState.Good);

                    break;
                case State.Miss:
                    uiManager.SetActiveNoteResult(state);
                    uiManager.UpdateNumberOfTimes(UIManager.NoteState.Miss);
                    uiManager.UpdateHealth(-1);
                    uiManager.UpdateCombo(-1);

                    break;
                default:
                    break;
            }
        }
    }



}
