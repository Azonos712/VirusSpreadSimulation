using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToActivityState : IState
{
    public HumanStateId GetId()
    {
        return HumanStateId.GoToActivity;
    }

    public void Enter(HumanBehavior human)
    {
        human.ActivityObject = ActivityPlaces.List[Random.Range(0, ActivityPlaces.List.Count)].gameObject;
        human.SetNextDestination(human.ActivityObject);
        //human.NavMesh.SetNextDestination(human.ActivityPlace);
        //human.PreviousPlace = human.CurrentPlace;
        //human.CurrentPlace = human.ActivityPlace;
    }

    public void Update(HumanBehavior human)
    {
        if (human.Arrived)
            human.StateMachine.ChangeState(HumanStateId.Activity);
    }

    public void Exit(HumanBehavior human)
    {
    }
}
