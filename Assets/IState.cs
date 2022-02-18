using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HumanStateId
{
    Spawn,
    GoToWork,
    Work,
    GoToHome,
    Rest,
    GoToActivity,
    Activity,
}

public interface IState
{
    HumanStateId GetId();
    void Enter(HumanBehavior human);
    void Update(HumanBehavior human);
    void Exit(HumanBehavior human);
}
