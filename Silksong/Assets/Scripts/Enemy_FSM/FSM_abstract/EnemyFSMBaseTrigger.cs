using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyFSMBaseTrigger
{
    public EnemyStates targetState;
    public EnemyTrigger triggerID;
    /// <summary>
    /// 构造赋值triggerTransitionID初始值
    /// </summary>
    /// <param name="trigger_TransitionID"></param>
    public EnemyFSMBaseTrigger(EnemyStates targetState)
    {
        this.targetState = targetState;
        InitTrigger();
    }

    /// <summary>
    /// 初始化方法，必要操作为赋值triggerID(自行编码赋值)，可做其他操作实现
    /// </summary>
    protected abstract void InitTrigger();
    /// <summary>
    /// 是否达到该条件的判断方法
    /// </summary>
    /// <param name="fsm_Manager">管理相应状态类的fsm_manager</param>
    /// <returns></returns>
    public abstract bool IsTriggerReach(EnemyFSMManager fsm_Manager);
}