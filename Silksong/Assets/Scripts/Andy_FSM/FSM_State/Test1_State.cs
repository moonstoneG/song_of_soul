using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AS_2D.FSM;

public class Test1_State: FSM_BaseState
{
    public override void Act_State(FSM_Manager fSM_Manager)
    {
        
        Debug.Log("这是默认状态Test1_State的行为操作");
    }

    protected override void InitState()
    {
        stateID = FSM_StateID.Test1;
    }
}
