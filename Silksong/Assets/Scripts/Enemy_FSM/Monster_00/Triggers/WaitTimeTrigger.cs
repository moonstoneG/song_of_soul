using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaitTimeTrigger : EnemyFSMBaseTrigger
{
    public float maxTime;
    public float timer;
    public WaitTimeTrigger(EnemyStates targetState,float time):base(targetState)
    {
        maxTime = time;
    }
    public override bool IsTriggerReach(EnemyFSMManager fsm_Manager)
    {
        timer += Time.deltaTime;
        if(timer>maxTime)
        {
            timer = 0;
            return true;
        }
        return false;
    }

    protected override void InitTrigger()
    {
        
    }
}
