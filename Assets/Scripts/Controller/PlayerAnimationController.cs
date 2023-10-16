using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : PlayerAnimations
{
    private static readonly int _Attack = Animator.StringToHash("Attack");

    protected override void Awake()
    {
        base.Awake();
    }

    void Start()
    {
        controller.OnAttackEvent += Attacking;
        //controller.OnMoveEvent += Move;
        if (StatusController != null)
        {
            //StatusController.OnDamage += Hit;
        }

        Debug.Log(animator == null);
        Debug.Log(controller == null);
    }

    //private void Move(Vector2 obj)
    //{
    //    animator.SetBool(IsWalking, obj.magnitude > 0.5f);
    //}

    private void Attacking()
    {
        animator.SetTrigger(_Attack);
    }

    //private void Hit()
    //{
    //    animator.SetBool(IsHit, true);
    //}
}
