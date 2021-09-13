using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InDetectionAreaTrigger :EnemyFSMBaseTrigger
{
    public float detectionRadius;
    public GameObject  detectTarget;
    public bool isEnterTrigger;
    protected override void InitTrigger()
    {
        triggerID = EnemyTrigger.InDetectionAreaTrigger;
    }
    public override bool IsTriggerReach(FSMManager<EnemyStates, EnemyTrigger> fsm_Manager)
    {
        if (detectTarget == null)
            return false;
        Vector3 v = detectTarget.transform.position - fsm_Manager.transform.position;
        if(v.sqrMagnitude<detectionRadius*detectionRadius)
        {
            if (isEnterTrigger)
                return true;
            else
                return false;
        }
        else
        {
            if (isEnterTrigger)
                return false;
            else
                return true;
        }
    }
}
