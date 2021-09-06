using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AS_2D.FSM;

public class Test2Trigger: FSM_BaseTrigger
{
    public override bool IsTriggerReach(FSM_Manager fsm_Manager)
    {
        Debug.Log("这里为test2的执行检测条件");
        if (true)
        {
            Debug.Log("满足条件的话返回false继续执行test2状态，此时继续检测所有test2状态的条件");
            return false;
        }
     }

    protected override void InitTrigger()
    {
        triggerID = FSM_TriggerID.Test2;
    }

}
