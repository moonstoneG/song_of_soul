using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Patrol_State : EnemyFSMBaseState
{
    private Enemy_Parameters param;
    public override void Act_State(EnemyFSMManager fSM_Manager)
    {
        fsmManager = fSM_Manager;
        param = fSM_Manager.param;
        Turn();
        Move();
    }
    private void Turn()
    {
        if(param.moveDirection.x<0)
        {
            fsmManager.param.isFaceRight = false;
            fsmManager.transform.localScale =new Vector3(-1, 1, 1);
        }
        else
        {
            fsmManager.param.isFaceRight = true;
            fsmManager.transform.localScale = new Vector3(1, 1, 1);
        }
        
    }
    private void Move()
    {
        fsmManager.transform.Translate(param.partrolSpeed * param.moveDirection * Time.deltaTime);
    }
    protected override void InitState()
    {
    }
}
