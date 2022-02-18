using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToWorkState : IState
{
    public HumanStateId GetId()
    {
        return HumanStateId.GoToWork;
    }

    public void Enter(HumanBehavior human)
    {
        human.SetNextDestination(human.WorkObject);
        //human.NavMesh.SetNextDestination(human.WorkObject);
        //human.PreviousPlace = human.CurrentPlace;
        //human.CurrentPlace = human.WorkObject;
    }

    public void Update(HumanBehavior human)
    {
        if (human.Arrived)
        {
            human.StateMachine.ChangeState(HumanStateId.Work);
        }
    }

    public void Exit(HumanBehavior human)
    {
    }
}
