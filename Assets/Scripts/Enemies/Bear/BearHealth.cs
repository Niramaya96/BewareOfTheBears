using UnityEngine;

public class BearHealth : MonoBehaviour,IDamageable
{
    [SerializeField] private float _health;

    public void TakeDamage(float value)
    {
        if (value >= 0)
        {
            _health -= value;
            Debug.Log(_health);
        }
        else
        {
            Debug.Log("Invalid value");
        }

        if (_health <= 0) Die();
    }
    public void Die()
    {
        gameObject.SetActive(false);
    }

}
