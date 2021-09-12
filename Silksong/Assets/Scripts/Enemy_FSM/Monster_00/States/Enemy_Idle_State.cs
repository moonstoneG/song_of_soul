using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
[Serializable]
public class Enemy_Idle_State : EnemyFSMBaseState
{
    public override void Act_State(EnemyFSMManager fSM_Manager)
    {
        fsmManager = fSM_Manager;
    }
    public override void EnterState(EnemyFSMManager fSM_Manager)
    {
        fsmManager.GetComponent<Rigidbody2D>().velocity = Vector3.zero;
    }
    protected override void InitState()
    {
        base.InitState();
    }
}
