using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToHomeState : IState
{
    public HumanStateId GetId()
    {
        return HumanStateId.GoToHome;
    }

    public void Enter(HumanBehavior human)
    {
        human.SetNextDestination(human.HomeObject);
        //human.NavMesh.SetNextDestination(human.HomePlace);
        //human.PreviousPlace = human.CurrentPlace;
        //human.CurrentPlace = human.HomePlace;
    }

    public void Update(HumanBehavior human)
    {
        if (human.Arrived)
        {
            human.StateMachine.ChangeState(HumanStateId.Rest);
        }
    }

    public void Exit(HumanBehavior human)
    {
    }

}
