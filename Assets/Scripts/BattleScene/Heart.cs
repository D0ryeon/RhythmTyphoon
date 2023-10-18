using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    SpriteRenderer SpriteRenderer;
    [SerializeField] Color DieStateColor;

    private Color DefaultColor;
    void Awake()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();
        DefaultColor = SpriteRenderer.color;
    }

   public void SetPosition(Vector3 position)
   {
        this.transform.position = position;
   }

   public void SetDieState()
   {
        SpriteRenderer.color = DieStateColor;
   }
    public void SetDefaultState()
    {
        SpriteRenderer.color = DefaultColor;
    }
}
