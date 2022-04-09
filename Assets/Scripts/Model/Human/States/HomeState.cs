using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomeState : IState
{
    private float _restTimeTick;
    private float _locationRadius;
    public HumanStateId GetId()
    {
        return HumanStateId.Rest;
    }
    public void Enter(HumanBehavior human)
    {
        _locationRadius = human.Home.LocationRadius;//.HomePlace.GetComponent<HomePlace>().LocationRadius;
        human.TimeRemainingInCurrentState = Random.Range(CityParams.MinHumansRestTime, CityParams.MaxHumansRestTime);
    }

    public void Update(HumanBehavior human)
    {
        if (_restTimeTick <= 0)
        {
            Vector2 point = Random.insideUnitCircle * _locationRadius;
            human.SetNextTargetInDestinationArea(new Vector3(point.x, 0, point.y));
            _restTimeTick = Random.Range(10, 40);
        }

        if (human.TimeRemainingInCurrentState <= 0)
        {
            var nextState = Random.value <= 0.5 ? HumanStateId.GoToWork : HumanStateId.GoToActivity;
            human.StateMachine.ChangeState(nextState);
        }

        _restTimeTick -= Time.deltaTime;
        human.TimeRemainingInCurrentState -= Time.deltaTime;
    }

    public void Exit(HumanBehavior human)
    {

    }
}
