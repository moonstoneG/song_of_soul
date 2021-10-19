using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbState : EnemyFSMBaseState
{
    public Vector2 range;
    public float maxSpeed = 2;
    public float force = 10;
    ContactPoint2D[] points = new ContactPoint2D[3];
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
    public override void Act_State(FSMManager<EnemyStates, EnemyTriggers> fSM_Manager)
    {
        base.Act_State(fSM_Manager);
        Force(fsmManager);
    }
    
    public  void Force(FSMManager<EnemyStates, EnemyTriggers> fsmManager)
    {
        Vector2 steeringForce = Vector2.zero;
        int n = fsmManager.GetComponent<Collider2D>().GetContacts(points);
        if (n > 0)
        {
            Vector2 toward = ((Vector2)fsmManager.transform.position - points[n - 1].point);
            steeringForce += -toward * force;
            fsmManager.transform.right = toward;
            fsmManager.rigidbody2d.velocity = new Vector2(toward.y, -toward.x) * maxSpeed;
        }
        fsmManager.rigidbody2d.AddForce(steeringForce);
    }
}
