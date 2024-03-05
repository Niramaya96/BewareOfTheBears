using System;
using UnityEngine;

public class OverlapAttack : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _damage;
    [SerializeField] private Animator _animator;

    [Header("OverlapArea")]
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private LayerMask _searchLayerMask;
    [SerializeField, Min(0f)] private float _sphereRadius = 1f;

    [Header("Gizmos")]
    [SerializeField] private Color _colorGizmos = Color.cyan;


    private readonly Collider[] _overlapResults = new Collider[10];
    private int _overlapCollidersCount;

    public void PerformAttack()
    {
        _animator.SetTrigger("Attack");

        if (TryFindEnemies())
        {
            TryAttackEnemies();
        }

    }
    private bool TryFindEnemies()
    {
        var position = _startPoint.TransformPoint(_offset);

        _overlapCollidersCount = OverlapSphere(position);

        return _overlapCollidersCount > 0;
    }

    private int OverlapSphere(Vector3 position)
    {
        return Physics.OverlapSphereNonAlloc(position, _sphereRadius,_overlapResults,_searchLayerMask.value);
    }

    private void TryAttackEnemies()
    {

        for (int i = 0; i < _overlapCollidersCount; i++)
        {
            if (_overlapResults[i].TryGetComponent(out IDamageable damageable) == false)
            {
                continue;
            }

            damageable.TakeDamage(_damage);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.matrix = _startPoint.localToWorldMatrix;
        Gizmos.color = _colorGizmos;

        Gizmos.DrawSphere(_offset,_sphereRadius);
    }

}
