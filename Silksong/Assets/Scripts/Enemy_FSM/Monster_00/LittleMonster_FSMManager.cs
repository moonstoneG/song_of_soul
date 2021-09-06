using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleMonster_FSMManager :EnemyFSMManager
{
    public override void InitStates()
    {
        AddState(EnemyStates.Idle, new Enemy_Idle_State());
        statesDic[EnemyStates.Idle].AddTriggers(new WaitTimeTrigger(EnemyStates.Patrol, param.IdleTime));

        AddState(EnemyStates.Patrol, new Enemy_Patrol_State());
        statesDic[EnemyStates.Patrol].AddTriggers(new WaitTimeTrigger(EnemyStates.Idle, param.partrolTime));
    }
}
