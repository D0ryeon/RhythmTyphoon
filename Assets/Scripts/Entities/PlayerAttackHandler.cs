using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerAttackHandler : MonoBehaviour
{

    [SerializeField] private float InputTime = 0.05f;
    private  Collider2D _hitbox;
    private CharactersController _controller;
    private Coroutine TimeChekcing;
    private bool IsChecking;

    public int checkNote = 0;

    private void Awake()
    {
        _hitbox = GetComponentInChildren<Collider2D>();
        _controller = GetComponent<CharactersController>();
    }

    private void Start()
    {
        _controller.OnAttackEvent += OnAttack;
    }

    void OnAttack()
    {
        IsChecking = true;
        SetEnabledTrue();
        Invoke("SetEnabledFalse", InputTime);
    }

    void SetEnabledTrue()
    {
        _hitbox.enabled = true;
    }

    void SetEnabledFalse()
    {
        IsChecking = false;
        _hitbox.enabled = false;
    }

    //private IEnumerator TimeCheck()
    //{
    //    IsChecking = true;
    //    Collider2D.enabled = true;

    //    yield return new WaitForSeconds(InputTime);

    //    IsChecking = false;
    //    Collider2D.enabled = false;
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (IsChecking)
        {
            collision.gameObject.SetActive(false);
            Debug.Log(checkNote);
            checkNote++;
            IsChecking = false;
            CancelInvoke("SetEnabledFalse");
        }
    }
}
