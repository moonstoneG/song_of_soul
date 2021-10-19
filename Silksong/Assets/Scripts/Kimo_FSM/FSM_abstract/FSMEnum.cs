using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum EnemyStates
{
    Enemy_Any_State,
    Enemy_Idle_State,
    Enemy_Patrol_State,
    Enemy_Hitted_State,
//<<<<<<< HEAD
    WanderState,
    PursuitState,
    ClimbState,
//=======
    Enemy_Attack_State,

//>>>>>>> 310d8bfdf1778417433501cb8f2772fa073c8446
}

public enum EnemyTriggers
{
    WaitTimeTrigger,
    HitWallTrigger,
    InDetectionAreaTrigger,
    AnimationPlayOverTrigger,
    OnHittedTrigger,
    PursuitTrigger,
    LoseTargetTrigger
}


public enum NPCStates
{
    NPC_Idle_State,
    NPC_Run_State
}

public enum NPCTriggers
{
    WaitTimeTrigger,
    HitWallTrigger,
    InDetectionAreaTrigger
}

public enum PlayerStates
{
    Player_Idle_State,
    Player_Run_State
}

public enum PlayerTriggers
{
    W_Key_Down,
    A_Key_Down,
    S_Key_Down,
    D_Key_Down
}
