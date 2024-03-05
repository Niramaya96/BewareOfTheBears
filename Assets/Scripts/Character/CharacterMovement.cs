using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMovement : MonoBehaviour, IMovable
{
    [Header("Character Movement Stats")]
    [SerializeField, Range(1, 5)] private float _movementSpeed = 3f;
    [SerializeField] private float _rotatetSpeed;

    [SerializeField] private Animator _animator;

    private Vector3 _moveDirection;
    private CharacterController _controller;


    private void Awake()
    {
        _controller = GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        MoveInternal();
        RotateCharacter();
    }

    public void Move(Vector3 direction)
    {
        _moveDirection = direction;
    }
    private void MoveInternal()
    {
        _animator.SetFloat("Speed", _moveDirection.sqrMagnitude);
        _controller.Move(_moveDirection * _movementSpeed * Time.deltaTime);
    }
    private void RotateCharacter()
    {
        if (Vector3.Angle(transform.forward, _moveDirection) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, _moveDirection, _rotatetSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }


}
