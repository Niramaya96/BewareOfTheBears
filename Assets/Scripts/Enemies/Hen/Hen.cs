using System;
using UnityEngine;

public class Hen : MonoBehaviour
{
    [SerializeField] private AudioSource _audioSource;

    [SerializeField] private int _health;

    public event Action HenDie;
    public void Die()
    {
        Destroy(gameObject);
        HenDie.Invoke();
    }

    public void TakeDamage(int damage)
    {
        _health -= damage;
        _audioSource.Play();

        if (_health <= 0) Die();
    }
}
