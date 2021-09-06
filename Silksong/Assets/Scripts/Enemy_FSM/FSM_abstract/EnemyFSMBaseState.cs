using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyFSMBaseState
{
    public EnemyFSMManager fsmManager;
    public EnemyStates stateID;
    /// <summary>
    /// 默认不赋值时，获取到为NullStateID枚举值，请在对应基类赋对应枚举ID值
    /// </summary>
    public EnemyStates StateID
    {
        get { return stateID; }
    }

    protected List<EnemyFSMBaseTrigger> triggers = new List<EnemyFSMBaseTrigger>();
  



    public EnemyFSMBaseState()
    {
        InitState();
    }

    /// <summary>
    /// 初始化方法，必要操作为赋值sateID(自行编码赋值)，可做其他操作实现
    /// </summary>
    /// <param name="fsm_StateID">赋值sateID</param>
    protected abstract void InitState();

    /// <summary>
    /// 为该状态添加条件列表类
    /// </summary>
    /// <param name="triggerID">要添加的条件的triggerID枚举，确保该枚举值和对应trgger类命对应正确</param>

    public void AddTriggers(EnemyTrigger triggerID,EnemyStates targetState) 
    {
        //Debug.Log(triggerID);

        Type type = Type.GetType(triggerID + "Trigger");
        if (type == null)
        {
            Debug.LogError(triggerID + "无法添加到" + stateID + "的triggers列表");
            Debug.LogError("检查满足Trigger条件的条件枚举，对应条件类命加上“Trigger”，如枚举值为PressBtn，条件类名为PreesBtnTrigger，便于配置加载；");
        }
        else 
        {
            triggers.Add(Activator.CreateInstance(type) as EnemyFSMBaseTrigger);
            triggers[triggers.Count - 1].targetState = targetState;
        }
    }
    public void AddTriggers(EnemyFSMBaseTrigger trigger)
    {
        triggers.Add(trigger);
    }


    /// <summary>
    /// 进入状态时调用
    /// </summary>
    public virtual void EnterState(EnemyFSMManager fSM_Manager) { }

    /// <summary>
    /// 退出状态时调用
    /// </summary>
    public virtual void ExitState(EnemyFSMManager fSM_Manager) { }

    /// <summary>
    /// 状态持续及刷新
    /// </summary>
    public abstract void Act_State(EnemyFSMManager fSM_Manager);
    /// <summary>
    /// 达到触发其他状态的条件然后执行该状态
    /// </summary>
    public virtual void TriggerState(EnemyFSMManager fsm_Manager)
    {
        for (int i = 0; i < triggers.Count; i++)
        {
            if (triggers[i].IsTriggerReach(fsm_Manager))
            {
                fsm_Manager.ChangeState(triggers[i].targetState);
            }
        }
    }


}
