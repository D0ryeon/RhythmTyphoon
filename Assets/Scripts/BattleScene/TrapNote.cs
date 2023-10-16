using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TrapNote : MonoBehaviour
{
    private const string Player = "Player";
    private const string Miss = "Miss";

    private Rigidbody2D rb;
    private Vector2 direction;
    private UIManager uiManager;

    public bool lastNote = false;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (uiManager.gameOver)
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
                uiManager.UpdateCombo(-1);
                uiManager.UpdateHealth(-1);
                Debug.Log("Trap Card!");
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
}
