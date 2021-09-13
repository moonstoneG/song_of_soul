using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitWallTrigger :EnemyFSMBaseTrigger
{
    private bool isHitWall;
    public bool isSigned=false;
    protected override void InitTrigger()
    {
        base.InitTrigger();
        triggerID = EnemyTrigger.HitWallTrigger;
        isHitWall = false;
        isSigned = false;
        
    }
    public override bool IsTriggerReach(FSMManager<EnemyStates, EnemyTrigger> fsm_Manager)
    {
        if(!isSigned)
        {
            EventsManager.Instance.AddListener(fsm_Manager.gameObject, EventType.onEnemyHitWall, HitTheWall);
            isSigned = true;
        }

        if (isHitWall)
        {
            isHitWall = false;
            return true;
        }
        else
            return false;
    }

    private void HitTheWall()
    {
        isHitWall = true;
    }
}
