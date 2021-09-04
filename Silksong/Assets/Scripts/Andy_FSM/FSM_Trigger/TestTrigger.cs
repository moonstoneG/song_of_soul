using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AS_2D.FSM;

public class TestTrigger: FSM_BaseTrigger
{
    public override bool IsTriggerReach(FSM_Manager fsm_Manager)
    {
        Debug.Log("这里为执行条件");
        if (true)
        {
            Debug.Log("满足条件的话执行只能操作若干于此");
            return true;
        }
     }

    protected override void InitTrigger()
    {
        triggerID = FSM_TriggerID.Test;
    }

}
