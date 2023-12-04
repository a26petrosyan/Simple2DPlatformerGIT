using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Player))]
[RequireComponent(typeof(Rigidbody2D))]

public class PlayerMover : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpForce;

    private Player _player;
    private Rigidbody2D _rigidbody;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _player = GetComponent<Player>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
        _animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (IsGrounded())
        {
            _animator.SetBool("IsJump", false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _rigidbody.AddForce(new Vector2(0, _jumpForce), ForceMode2D.Impulse);
            }
        }
        else
        {
            _animator.SetBool("IsJump", true);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            _player.transform.Translate(_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = false;
            _animator.SetBool("IsRun", true);
        }

        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            _animator.SetBool("IsRun", false);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _player.transform.Translate(-_speed * Time.deltaTime, 0, 0);
            _spriteRenderer.flipX = true;
            _animator.SetBool("IsRun", true);
        }

        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            _animator.SetBool("IsRun", false);
        }
    }

    private bool IsGrounded()
    {
        var raycastHit2D = Physics2D.CircleCastAll(transform.position, 1, Vector2.zero);
        return raycastHit2D.Length > 1;
    }
}
