using System;
using System.Collections.Generic;

public class Fsm 
{
   private FsmState _currentState { get; set; }

   private Dictionary<Type,FsmState> _fsmStates = new Dictionary<Type,FsmState>();


   public void AddState(FsmState state)
   {
        _fsmStates.Add(state.GetType(), state);
   }

    public void SetState<T>() where T : FsmState
    {
        var type = typeof(T);

        if (_currentState != null && _currentState.GetType() == type) return;

        if (_fsmStates.TryGetValue(type,out var state) ) 
        {
            _currentState = state;

            _currentState.Enter();
        }
    }
    public void FixedUpdate()
    {
        _currentState.FixedUpdate();
    }
    public void Update()
    {
        _currentState?.Update();
    }
}
