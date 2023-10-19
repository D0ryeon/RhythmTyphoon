using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEndZone : MonoBehaviour
{
    BoxCollider2D BoxCollider2D;

    private void Awake()
    {
        BoxCollider2D = GetComponent<BoxCollider2D>();
    }

    public void ClearAllNote()
    {
        BoxCollider2D.size = new Vector2(35, 10);
        Invoke(nameof(ResetSize), 0.5f);
    }

    public void ResetSize()
    {
        BoxCollider2D.size = new Vector2(1, 5);
    }
}
