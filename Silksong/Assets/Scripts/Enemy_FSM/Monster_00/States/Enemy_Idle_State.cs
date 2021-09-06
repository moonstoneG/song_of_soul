using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Idle_State : EnemyFSMBaseState
{
    public override void Act_State(EnemyFSMManager fSM_Manager)
    {
        fsmManager = fSM_Manager;
    }

    protected override void InitState()
    {

    }
}
