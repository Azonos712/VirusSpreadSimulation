using System;
using UnityEngine;

public class HumanStateMachine
{
    [SerializeField] private HumanStateId _currentState;
    public HumanStateId CurrentState
    {
        get
        {
            return _currentState;
        }
        private set
        {
            OnStateChanged?.Invoke(_currentState, value);
            _currentState = value;
        }
    }

    //[SerializeField] private HumanStateId _previousState;
    //public HumanStateId PreviousState => _previousState;

    public event Action<HumanStateId, HumanStateId> OnStateChanged;

    private IState[] _states;
    private HumanBehavior _human;

    public HumanStateMachine(HumanBehavior human)
    {
        _human = human;
        int numStates = Enum.GetNames(typeof(HumanStateId)).Length;
        _states = new IState[numStates];
    }

    public void RegisterState(IState state)
    {
        int index = (int)state.GetId();
        _states[index] = state;
    }

    private IState GetState(HumanStateId state)
    {
        int index = (int)state;
        return _states[index];
    }

    public void Update()
    {
        GetState(CurrentState)?.Update(_human);
    }

    public void ChangeState(HumanStateId newState)
    {
        GetState(CurrentState)?.Exit(_human);
        CurrentState = newState;
        GetState(CurrentState)?.Enter(_human);
    }
}
