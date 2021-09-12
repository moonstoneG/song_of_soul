using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyStates
{
    Enemy_Idle_State,
    Enemy_Patrol_State,
    Enemy_Chase_State,
    Enemy_Hitted_State,
    Enemy_Attack_State,
    Enemy_Die_State
}

public enum EnemyTrigger
{
    WaitTimeTrigger,
    HitWallTrigger,
    InDetectionAreaTrigger
}

