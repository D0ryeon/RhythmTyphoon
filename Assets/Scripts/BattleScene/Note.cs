using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class Note : MonoBehaviour
{
    private const string Player = "Player";
    private const string Miss = "Miss";

    private Rigidbody2D rb;
    private Vector2 direction;
    private UIManager uiManager;

    [SerializeField] private float _goodRange;
    [SerializeField] private float _perfectRange;

    public bool lastNote= false;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(uiManager.gameOver)
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
            if (player.movigToHitPosition)
            {
                Vector2 collisionPoint = collision.ClosestPoint(transform.position);
                float xDistanceFromCollisionPoint = Mathf.Abs(collisionPoint.x - this.transform.position.x);
                Debug.Log(xDistanceFromCollisionPoint);
                if (xDistanceFromCollisionPoint < _perfectRange)
                {
                    Debug.Log("Perfect!");
                    uiManager.UpdateScore(100);
                    uiManager.UpdateCombo(1);
                    uiManager.UpdateNumberOfTimes(UIManager.NoteState.Perfect);
                }
                else
                {
                    Debug.Log("Good");
                    uiManager.UpdateScore(50);
                    uiManager.UpdateCombo(1);
                    uiManager.UpdateNumberOfTimes(UIManager.NoteState.Good);
                }
            }
            else
            {
                return;
            }
        }
        else if(collision.CompareTag(Miss)) 
        {
            uiManager.UpdateNumberOfTimes(UIManager.NoteState.Miss);
            uiManager.UpdateHealth(-1);
        }

        if (lastNote)
        {
            uiManager.UpdateGameState(UIManager.GameState.GameClear);
        }
        this.gameObject.SetActive(false);
    }

    public void InitializeDirection(Vector2 direction)=>this.direction = direction; 

    public void SetUIManager(UIManager uiManager)=>this.uiManager = uiManager;
}
