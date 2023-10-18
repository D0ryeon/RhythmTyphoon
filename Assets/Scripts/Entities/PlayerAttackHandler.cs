using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{

    [SerializeField] private  Collider2D hitbox; //나중에 히트박스가 완전히 정해지면 코드로 구현할 것
    private CharactersController _controller;
    private float AttackSync = 0;

    private void Awake()
    {
        _controller = GetComponent<CharactersController>();
    }

    private void Start()
    {
        _controller.OnAttackEvent += OnAttack;
    }

    void OnAttack()
    {
        Invoke("SetActiveHitBox", AttackSync);
    }

    void SetActiveHitBox()
    {
        hitbox.enabled = true;
    }
}
