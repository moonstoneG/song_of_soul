using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : EnemyFSMBaseState
{
    public float wanderRadius=3;
    public Vector2 wanderCenter;
    public float forceToCenter = 2;
    public override void InitState(FSMManager<EnemyStates, EnemyTriggers> fSMManager)
    {
        base.InitState(fSMManager);
        fsmManager = fSMManager;
        wanderCenter = fsmManager.transform.position;
        stateID = EnemyStates.WanderState;
    }
    public override void EnterState(FSMManager<EnemyStates, EnemyTriggers> fSM_Manager)
    {
        base.EnterState(fSM_Manager);
        wanderCenter = fsmManager.transform.position;
    }
    public override void Act_State(FSMManager<EnemyStates, EnemyTriggers> fSM_Manager)
    {
        base.Act_State(fSM_Manager);
        if (Vector2.Distance(wanderCenter, fsmManager.transform.position) > wanderRadius)
        {
            fsmManager.rigidbody2d.AddForce((wanderCenter - (Vector2)fsmManager.transform.position).normalized * forceToCenter);
        }
    }
}
