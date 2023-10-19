using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{

    [SerializeField] private Transform HitPosition;
    [SerializeField] private Transform DefaultPosition;

    private Rigidbody2D rb;

    [SerializeField] private bool movigToHitPosition = false;
    [SerializeField] private bool movingToDefalutPosition = false;
    
    public float swingSpeed = 100.0f;
    public float returnSpeed = 50.0f;

    [SerializeField] private Vector2 direction;
    [SerializeField] private Vector2 returnDirection;

    private void Awake()
    {
        rb= GetComponent<Rigidbody2D>();
        SetDirections();
    }

    private void FixedUpdate()
    {
        if(!movigToHitPosition && !movingToDefalutPosition)
        {
            //Stop
            rb.velocity = Vector2.zero;
            return;
        }
        if (movigToHitPosition)
        {
            if(this.transform.position.y <= HitPosition.position.y)
            {
                movigToHitPosition=false;
                movingToDefalutPosition =true;
            }
            // move To note
            rb.velocity =swingSpeed * Time.deltaTime * direction;
        }
        else if (movingToDefalutPosition)
        {
            // move To defalut position
            rb.velocity = returnSpeed * Time.deltaTime * returnDirection;
            if(this.transform.position.y >= DefaultPosition.position.y)
            {
                movingToDefalutPosition=false;
            }
        }

        return;
    }

    private void SetDirections()
    {
        direction = (HitPosition.position - DefaultPosition.position).normalized;
        returnDirection = -direction;
    }

    void OnAttack()
    {
        movigToHitPosition = true;
        movingToDefalutPosition = false;
    }
}
