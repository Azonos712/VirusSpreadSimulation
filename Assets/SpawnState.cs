using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnState : IState
{
    public HumanStateId GetId()
    {
        return HumanStateId.Spawn;
    }
    public void Enter(HumanBehavior human)
    {
        GetRandomWork(human);

        var nextState = Random.value <= 0.5 ? HumanStateId.GoToWork : HumanStateId.GoToActivity;
        human.StateMachine.ChangeState(nextState);
    }

    private void GetRandomWork(HumanBehavior human)
    {
        WorkPlace work;
        do
        {
            work = WorkPlaces.List[Random.Range(0, WorkPlaces.List.Count)];
        } while (work.ListOfWorkers.Count >= work.MaxNumOfWorkers);

        work.ListOfWorkers.Add(human.gameObject);
        human.WorkObject = work.gameObject;
    }

    public void Update(HumanBehavior human)
    {

    }

    public void Exit(HumanBehavior human)
    {

    }
}