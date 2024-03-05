using UnityEngine;
using UnityEngine.AI;

public class FsmStateMove : FsmState
{
    private Transform _target;
    private NavMeshAgent _agent;
    private Bear _bear;
    public FsmStateMove(Fsm fsm, Bear bear, NavMeshAgent agent) : base(fsm)
    {
        _bear = bear;
       _agent = agent;
    }

    public override void Enter()
    {
        if (_target == null) _bear.SetNewTarget();
        _target = _bear.Target.transform;
    }

    public override void Update()
    {
        if (Vector3.Distance(_agent.transform.position, _target.position) <= 2f)
            Exit();
    }
    public override void FixedUpdate()
    {
        Move();
    }
    private void Move()
    {
        _agent.SetDestination(_target.position);
    }

    public override void Exit()
    {
        Fsm.SetState<FsmStateAttack>();
    }
}

