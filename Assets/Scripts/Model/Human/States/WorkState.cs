using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkState : IState
{
    private float _workTimeTick;
    private float _locationRadius;

    public HumanStateId GetId()
    {
        return HumanStateId.Work;
    }

    public void Enter(HumanBehavior human)
    {
        _locationRadius = human.Work.LocationRadius;//human.Wor.GetComponent<WorkPlace>().LocationRadius;
        human.TimeRemainingInCurrentState = Random.Range(CityParams.MinHumansWorkTime, CityParams.MaxHumansWorkTime);
        
        if (human.HealthStatus == HealthStatus.Infected)
            human.TimeRemainingInCurrentState /= 3;

    }

    public void Update(HumanBehavior human)
    {
        if (_workTimeTick <= 0)
        {
            Vector2 point = Random.insideUnitCircle * _locationRadius;
            human.SetNextTargetInDestinationArea(new Vector3(point.x, 0, point.y));
            _workTimeTick = Random.Range(10, 40);
        }

        if (human.TimeRemainingInCurrentState <= 0)
        {
            var nextState = Random.value <= 0.5 ? HumanStateId.GoToHome : HumanStateId.GoToActivity;
            human.StateMachine.ChangeState(nextState);
        }

        _workTimeTick -= Time.deltaTime;
        human.TimeRemainingInCurrentState -= Time.deltaTime;
    }

    public void Exit(HumanBehavior human)
    {
    }
}
