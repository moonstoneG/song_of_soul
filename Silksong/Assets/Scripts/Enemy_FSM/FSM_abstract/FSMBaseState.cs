using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public  class FSMBaseState<T1,T2>
{
    protected FSMManager<T1,T2> fsmManager;
    [DisplayOnly]
    public  T1 stateID;
    /// <summary>
    /// 默认不赋值时，获取到为NullStateID枚举值，请在对应基类赋对应枚举ID值
    /// </summary>

    protected List<FSMBaseTrigger<T1,T2>> triggers = new List<FSMBaseTrigger<T1,T2>>();
    public void ClearTriggers()
    {
        triggers.Clear();
    }



    public FSMBaseState()
    {
        InitState();
    }

    /// <summary>
    /// 初始化方法，必要操作为赋值sateID(自行编码赋值)，可做其他操作实现
    /// </summary>
    /// <param name="fsm_StateID">赋值sateID</param>
    protected virtual void InitState() { triggers.Clear(); }

    /// <summary>
    /// 为该状态添加条件列表类
    /// </summary>
    /// <param name="triggerID">要添加的条件的triggerID枚举，确保该枚举值和对应trgger类命对应正确</param>

    public void AddTriggers(T2 triggerID,T1 targetState) 
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
            triggers.Add(Activator.CreateInstance(type) as FSMBaseTrigger<T1,T2>);
            triggers[triggers.Count - 1].targetState = targetState;
        }
    }
    public void AddTriggers(FSMBaseTrigger<T1,T2> trigger)
    {
        triggers.Add(trigger);
    }


    /// <summary>
    /// 进入状态时调用
    /// </summary>
    public virtual void EnterState(FSMManager<T1,T2> fSM_Manager) { }

    /// <summary>
    /// 退出状态时调用
    /// </summary>
    public virtual void ExitState(FSMManager<T1,T2> fSM_Manager) { }

    /// <summary>
    /// 状态持续及刷新
    /// </summary>
    public virtual void Act_State(FSMManager<T1,T2> fSM_Manager) { }
    /// <summary>
    /// 达到触发其他状态的条件然后执行该状态
    /// </summary>
    public virtual void TriggerState(FSMManager<T1,T2> fsm_Manager)
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
public class EnemyFSMBaseState : FSMBaseState<EnemyStates,EnemyTrigger> 
{

}
