using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovementHandler : MonoBehaviour
{
    private CharactersController _controller;

    private Vector2 _movementDirection = Vector2.zero;
    private Rigidbody2D _rigidbody;
    private IBaseData _data;
    private SpriteRenderer _renderer;

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

    private void FixedUpdate()
    {
        ApplyMovement(_movementDirection);
    }


    private void Move(Vector2 direction)
    {
        if(direction.x > 0)
        {
            _renderer.flipX = true;
        }
        else if(direction.x < 0)
        {
            _renderer.flipX = false;
        }
        _movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * _data.Speed;
        _rigidbody.velocity = direction;
    }
}
