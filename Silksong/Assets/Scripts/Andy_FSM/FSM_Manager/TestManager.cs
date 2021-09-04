using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AS_2D.FSM;

public class TestManager : FSM_Manager
{
    public override void InitStates()
    {
        base.InitStates();
        //以下为手动编码添加的方法
        //Test1_State test1_State = new Test1_State();
        //Test2_State test2_State = new Test2_State();

        //states.Add(test1_State);
        //states.Add(test2_State);
        
        //test1_State.AddTriggerStateID_map(FSM_TriggerID.Test,FSM_StateID.Test2);
    }
}
