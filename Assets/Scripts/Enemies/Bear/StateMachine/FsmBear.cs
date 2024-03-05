using UnityEngine;
using UnityEngine.AI;

public class FsmBear : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private Bear _bear;

    private Fsm _fsm;

    private void Start()
    {
        _fsm = new Fsm();

        _fsm.AddState(new FsmStateMove(_fsm,_bear,_agent));
        _fsm.AddState(new FsmStateAttack(_fsm, _bear));
        SetStartState();

    }
    private void SetStartState()
    {
        _fsm.SetState<FsmStateMove>();
    }

    private void Update()
    {
        _fsm.Update();
    }
    private void FixedUpdate()
    {
        _fsm.FixedUpdate();
    }

}
