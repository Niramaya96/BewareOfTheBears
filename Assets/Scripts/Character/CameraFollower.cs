using System;
using UnityEngine;

public class CameraFollower : MonoBehaviour
{
    [SerializeField] private Transform _target;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private float _smoothing;

    private void FixedUpdate()
    {
        Move();
    }

    private void Move()
    {
        var nextPosition = Vector3.Lerp(transform.position,_target.position + _offset,Time.fixedDeltaTime * _smoothing);

        transform.position = nextPosition;
    }
}
