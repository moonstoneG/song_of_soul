using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitTrigger : EnemyFSMBaseTrigger
{
    public float range;
    public LayerMask layer;
    public override void InitTrigger(FSMManager<EnemyStates, EnemyTriggers> fSMManager)
    {
        base.InitTrigger(fSMManager);
        triggerID = EnemyTriggers.PursuitTrigger;
        targetState = EnemyStates.PursuitState;
    }
    public override bool IsTriggerReach(FSMManager<EnemyStates, EnemyTriggers> fsm_Manager)
    {
        Collider2D target = Physics2D.OverlapCircle(fsm_Manager.transform.position, range,layer);
        if (target)
        {
            PursuitState pursuit = (PursuitState)fsm_Manager.statesDic[EnemyStates.PursuitState];
            pursuit.target = target.transform;
            return true;
        }
        return false;
    }
}
