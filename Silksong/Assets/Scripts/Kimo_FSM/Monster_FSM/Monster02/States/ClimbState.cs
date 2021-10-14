using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : EnemyFSMBaseState
{
    /*public float moveSpeed;
    public float force;
    Vector2 toward;
    ContactPoint2D[] points=new ContactPoint2D[10];*/
    float g;
    public override void EnterState(FSMManager<EnemyStates, EnemyTriggers> fSM_Manager)
    {
        base.EnterState(fSM_Manager);
        g = fsmManager.rigidbody2d.gravityScale;
        fsmManager.rigidbody2d.gravityScale = 0;
    }

    public override void ExitState(FSMManager<EnemyStates, EnemyTriggers> fSM_Manager)
    {
        base.ExitState(fSM_Manager);
        fsmManager.rigidbody2d.gravityScale = g;
    }
    public override void InitState(FSMManager<EnemyStates, EnemyTriggers> fSMManager)
    {
        base.InitState(fSMManager);
        fsmManager = fSMManager;
        stateID = EnemyStates.ClimbState;
    }
}
