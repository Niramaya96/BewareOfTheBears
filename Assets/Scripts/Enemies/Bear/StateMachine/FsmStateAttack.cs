using UnityEngine;

public class FsmStateAttack : FsmState
{
        private Bear _bear;
        private Hen _hen;
        private float _delay;

      public FsmStateAttack(Fsm fsm,Bear bear) : base(fsm)
      {
            _bear = bear;
      }

        public override void Enter()
        {
            if (_bear.Target.TryGetComponent<Hen>(out var hen))
            {
                _hen = _bear.Target;
            }

        }
        public override void Update() 
        {
            if (_hen == null)
            {
                Exit();
            }

            AttackHen();
        }
        public override void Exit() 
        {
            Fsm.SetState<FsmStateMove>();
        }
        private void AttackHen()
        {
            if (_delay >= 2f)
            {
                _hen.TakeDamage(1);
                _delay = 0f;
            }
            _delay += Time.deltaTime;
        
        }


}
