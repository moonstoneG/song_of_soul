using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AS_2D.FSM;

public class Test2_State : FSM_BaseState
{
    public override void Act_State(FSM_Manager fSM_Manager)
    {
        Debug.Log("这里是test1状态满足test条件后切换到的test2行为状态");
    }

    protected override void InitState()
    {
        stateID = FSM_StateID.Test2;
    }
}
