using UnityEngine;


public class Bear : MonoBehaviour
{
    [SerializeField] private Animator _animator;

    private HenSpawner _henSpawner;
    private Hen _target;

    public Animator Animator { get => _animator;}
    public Hen Target { get => _target; }

    private void OnEnable()
    {
        SetNewTarget();
        Target.HenDie += OnHenDie;
    }
    public void InitializeBear(HenSpawner henSpawner)
    {
        _henSpawner = henSpawner;
    }
    public void SetNewTarget()
    {
        _target = _henSpawner.GetHenTarget().GetComponent<Hen>();
    }
    private void OnHenDie()
    {
        SetNewTarget();
    }

    private void OnDisable()
    {
        Target.HenDie -= OnHenDie;
    }

}
