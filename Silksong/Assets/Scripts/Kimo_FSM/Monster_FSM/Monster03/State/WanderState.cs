using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WanderState : EnemyFSMBaseState
{
    public float wanderRange=3;
    public Vector2 wanderCenter;
    public float forceToCenter = 2;
    public float wanderRadiu = 1;
    public float wanderJitter = 1;
    public float maxSpeed;
    public Vector2 targetPos = Vector2.right;
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
        Force(fsmManager);
        if (Vector2.Distance(wanderCenter, fsmManager.transform.position) > wanderRange)
        {
            fsmManager.rigidbody2d.AddForce((wanderCenter - (Vector2)fsmManager.transform.position).normalized * forceToCenter);
        }
    }
    public void Force(FSMManager<EnemyStates, EnemyTriggers> fsmManager)
    {
        targetPos.x += Random.Range(-1, 2);
        targetPos.y += Random.Range(-1, 2);
        targetPos.Normalize();
        targetPos *= wanderRadiu;
        Vector2 target = fsmManager.rigidbody2d.velocity.normalized * wanderJitter + targetPos;
        Vector2 desiredVelocity = target.normalized * maxSpeed;
        fsmManager.rigidbody2d.AddForce(desiredVelocity - fsmManager.rigidbody2d.velocity);
    }
}
