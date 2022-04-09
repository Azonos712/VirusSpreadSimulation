using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivityState : IState
{
    private float _activityTimeTick;
    private float _locationRadius;

    public HumanStateId GetId()
    {
        return HumanStateId.Activity;
    }

    public void Enter(HumanBehavior human)
    {
        _locationRadius = human.Work.LocationRadius;//.WorkPlace.GetComponent<WorkPlace>().LocationRadius;
        human.TimeRemainingInCurrentState = Random.Range(CityParams.MinHumansActivityTime, CityParams.MaxHumansActivityTime);
    }

    public void Update(HumanBehavior human)
    {
        if (_activityTimeTick <= 0)
        {
            Vector2 point = Random.insideUnitCircle * _locationRadius;
            human.SetNextTargetInDestinationArea(new Vector3(point.x, 0, point.y));
            _activityTimeTick = Random.Range(10, 20);
        }

        if (human.TimeRemainingInCurrentState <= 0)
        {
            var nextState = human.PreviousObject == human.WorkObject ? HumanStateId.GoToHome : HumanStateId.GoToWork;
            human.StateMachine.ChangeState(nextState);
        }

        _activityTimeTick -= Time.deltaTime;
        human.TimeRemainingInCurrentState -= Time.deltaTime;
    }

    public void Exit(HumanBehavior human)
    {
    }
}
