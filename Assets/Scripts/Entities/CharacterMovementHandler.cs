using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterMovementHandler : MonoBehaviour
{
    private CharactersController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private IBaseData _data;
    private SpriteRenderer _renderer;
    public Animator _anim;

    private void Awake()
    {
        _controller = GetComponent<CharactersController>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _renderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {
        _controller.OnMoveEvent += Move;
        if (gameObject.tag == "Player")
        {
            _data = DataBase.Instance.PlayerData;
        }
        else
        {
            Debug.Log("Tag를 제대로 설정해 주세요.");
        }
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.D))
        {
            _anim.SetBool("Work_right", false);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            _anim.SetBool("Work_left", false);
        }
    }

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }


    private void Move(Vector2 direction)
    {
        if(direction.x > 0)
        {
            _anim.SetBool("Work_right", true);
        }
        else if(direction.x < 0)
        {
            _anim.SetBool("Work_left",true);
        }
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _data.Speed;
        _rigidbody.velocity = direction;
    }
}
