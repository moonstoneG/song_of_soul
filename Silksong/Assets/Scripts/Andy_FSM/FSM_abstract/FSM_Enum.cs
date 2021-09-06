using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AS_2D.FSM
{


    /// <summary>
    /// State状态枚举，和对应状态类命保持一致
    /// </summary>
    public enum FSM_StateID
    {
        NullStateID = 0,
        /// <summary>
        /// 原地状态
        /// </summary>
        Idle,
        Walk,
        Run,
        Jump,
        JumpTwice,
        /// <summary>
        /// 爬墙
        /// </summary>
        ClimbWall,
        /// <summary>
        /// 爬梯子
        /// </summary>
        ClimbLadder,
        /// <summary>
        /// 冲刺
        /// </summary>
        Dash,
        /// <summary>
        /// 二段冲刺
        /// </summary>
        DashTwice,
        Test1,
        Test2,
    }
    /// <summary>
    /// 满足Trigger条件的条件枚举，对应条件类命加上“Trigger”，如枚举值为PressBtn，条件类名为PreesBtnTrigger，便于配置加载；
    /// </summary>
    public enum FSM_TriggerID
    {
        NullTriggerTransition = 0,
        /// <summary>
        /// 按下左右移动按键
        /// </summary>
        PressHorizontalBtn,
        /// <summary>
        /// 按下上下移动按键
        /// </summary>
        PressVerticalBtn,
        /// <summary>
        /// 按下跳跃按键
        /// </summary>
        PressJumpBtn,
        /// <summary>
        /// 按下二段跳按键
        /// </summary>
        PressJumpTwiceBtn,
        /// <summary>
        /// 按下冲刺按键
        /// </summary>
        PressDashBtn,
        /// <summary>
        /// 按下二段冲刺按键
        /// </summary>
        PressDsahTwiceBtn,
        Test,
        Test2,
    }
}

