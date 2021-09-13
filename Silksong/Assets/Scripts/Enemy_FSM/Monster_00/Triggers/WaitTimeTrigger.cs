using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class WaitTimeTrigger : EnemyFSMBaseTrigger
{
    public float maxTime;
    [DisplayOnly]
    public float timer;

    public WaitTimeTrigger():base()
    {
        maxTime = 0;
    }
    public WaitTimeTrigger(float time,EnemyStates targetState=EnemyStates.Enemy_Idle_State):base(targetState)
    {
        maxTime = time;
    }
    public override bool IsTriggerReach(FSMManager<EnemyStates, EnemyTrigger> fsm_Manager)
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
        timer = 0;
    }
}
