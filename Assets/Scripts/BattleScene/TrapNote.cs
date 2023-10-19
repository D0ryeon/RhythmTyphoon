using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class TrapNote : NoteBasic
{
    protected override void Awake()
    {
        base.Awake();
    }

    protected override void FixedUpdate()
    {
        base.FixedUpdate();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Player))
        {
            uiManager.UpdateHealth(-1);
            uiManager.UpdateCombo(-1);
        }
        this.gameObject.SetActive(false);
    }
}
