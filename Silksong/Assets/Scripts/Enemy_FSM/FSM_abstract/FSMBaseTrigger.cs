using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization;

[Serializable]
public  class FSMBaseTrigger<T1,T2>
{
    [DisplayOnly]
    public T2 triggerID;
    public T1 targetState;
    public FSMBaseTrigger()
    {
        InitTrigger();
    }
    public FSMBaseTrigger(T1 targetState)
    {
        this.targetState = targetState;
        InitTrigger();
    }


    protected virtual void InitTrigger() { }
    /// <summary>
    /// 是否达到该条件的判断方法
    /// </summary>
    /// <param name="fsm_Manager">管理相应状态类的fsm_manager</param>
    /// <returns></returns>
    public virtual bool IsTriggerReach(FSMManager<T1,T2> fsm_Manager) { return false; }

}
public class EnemyFSMBaseTrigger : FSMBaseTrigger<EnemyStates, EnemyTrigger> 
{
    public EnemyFSMBaseTrigger(EnemyStates targetState):base(targetState){ }
    public EnemyFSMBaseTrigger(){ }
}