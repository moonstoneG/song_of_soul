using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PursuitState : EnemyFSMBaseState
{
    public Transform target;
    public override void InitState(FSMManager<EnemyStates, EnemyTriggers> fSMManager)
    {
        base.InitState(fSMManager);
        fsmManager = fSMManager;
        stateID = EnemyStates.PursuitState;
    }

}
