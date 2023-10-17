using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Note : MonoBehaviour
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

    [SerializeField] private float _goodRange;
    [SerializeField] private float _perfectRange;

    public bool lastNote= false;

    [SerializeField] private GameObject _perfectZone;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 perfectZoneScale = _perfectZone.transform.localScale;
        perfectZoneScale.x = _perfectRange *2;
        _perfectZone.transform.localScale = perfectZoneScale;

        state = State.Default;
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
                Vector2 collisionPoint = collision.ClosestPoint(transform.position);
                float xDistanceFromCollisionPoint = Mathf.Abs(collisionPoint.x - this.transform.position.x);
                
                if (xDistanceFromCollisionPoint < _perfectRange)
                {
                    Debug.Log("Perfect!");
                    if(uiManager != null)
                    {
                        uiManager.UpdateScore(100);
                        uiManager.UpdateCombo(1);
                        uiManager.UpdateNumberOfTimes(UIManager.NoteState.Perfect);
                    }
                 
                    state = State.Perfect;
                    NoteStateChange();
                }
                else
                {
                    Debug.Log("Good");
                    if (uiManager != null)
                    {
                        uiManager.UpdateScore(50);
                        uiManager.UpdateCombo(1);
                        uiManager.UpdateNumberOfTimes(UIManager.NoteState.Good);
                        state = State.Good;
                    }
                    NoteStateChange();
                }
            }
            else
            {
                return;
            }
        }
        else if(collision.CompareTag(Miss)) 
        {
            if (uiManager != null)
            {
                uiManager.UpdateNumberOfTimes(UIManager.NoteState.Miss);
                uiManager.UpdateHealth(-1);
                uiManager.UpdateCombo(-1);
            }
            state = State.Miss;
            NoteStateChange();
        }

        if (lastNote && uiManager != null)
        {
            uiManager.UpdateGameState(UIManager.GameState.GameClear);
        }
        this.gameObject.SetActive(false);
    }

    public void SetDirection(Vector2 direction)=>this.direction = direction; 

    public void SetUIManager(UIManager uiManager)=>this.uiManager = uiManager;

    // �� �ؿ��� State�� ���� �ٸ� ������ �ϰ� �ϸ� �˴ϴ�. 
    private void NoteStateChange()
    {
        switch(state)
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
