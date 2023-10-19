using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackHandler : MonoBehaviour
{

    [SerializeField] private  Collider2D hitbox; //���߿� ��Ʈ�ڽ��� ������ �������� �ڵ�� ������ ��
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
