using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AS_2D.FSM
{
    public abstract class FSM_BaseState
    {
        public FSM_Manager fsmManager;
        public FSM_StateID stateID;
        /// <summary>
        /// 默认不赋值时，获取到为NullStateID枚举值，请在对应基类赋对应枚举ID值
        /// </summary>
        public FSM_StateID StateID
        {
            get
            {
                if (stateID != FSM_StateID.NullStateID)
                {
                    return stateID;
                }
                Debug.Log("请在对应基类的stateID赋对应枚举ID值，当前未赋值为FSM_StateID.NullStateID");
                return FSM_StateID.NullStateID;
            }
        }

        protected List<FSM_BaseTrigger> triggers = new List<FSM_BaseTrigger>();
        /// <summary>
        /// 触发条件和状态ID对应的字典映射表
        /// </summary>
        protected Dictionary<FSM_TriggerID, FSM_StateID> TriggerStateID_map = new Dictionary<FSM_TriggerID, FSM_StateID>();


       
        public FSM_BaseState()
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

        public void AddTriggers(FSM_TriggerID triggerID) {
            //Debug.Log(triggerID);
            
            Type type = Type.GetType(triggerID + "Trigger");
            if (type == null)
            {
                Debug.LogError(triggerID + "无法添加到" + stateID + "的triggers列表");
                Debug.LogError("检查满足Trigger条件的条件枚举，对应条件类命加上“Trigger”，如枚举值为PressBtn，条件类名为PreesBtnTrigger，便于配置加载；");
            }
            else {
                triggers.Add(Activator.CreateInstance(type) as FSM_BaseTrigger);
            }
        }

        /// <summary>
        /// 添加触发条件及对应状态
        /// </summary>
        /// <param name="_triggerID">触发条件枚举值</param>
        /// <param name="ID">状态枚举值</param>
        public void AddTriggerStateID_map(FSM_TriggerID _triggerID,FSM_StateID ID) {
            if (_triggerID == FSM_TriggerID.NullTriggerTransition)
            {
                Debug.LogError("不能进行NullTriggerTransition的添加");
                return;
            }
            if (ID == FSM_StateID.NullStateID)
            {
                Debug.LogError("不能进行NullStateID的添加");
                return;
            }
            if (TriggerStateID_map.ContainsKey(_triggerID))
            {
                Debug.LogError(_triggerID+"触发条件已存在，无法再次添加");
                return;
            }
            //AddTriggers(_triggerID);
            TriggerStateID_map.Add(_triggerID, ID);
        }


        /// <summary>
        /// 删除触发条件以及对应的状态
        /// </summary>
        /// <param name="trigger">触发条件枚举值</param>
        public void DeleteTriggerStateID_map(FSM_TriggerID trigger)
        {
            if (trigger == FSM_TriggerID.NullTriggerTransition)
            {
                Debug.LogError("不能进行NullTriggerTransition的删除");
                return;
            }
            
            if (!TriggerStateID_map.ContainsKey(trigger))
            {
                Debug.LogError(trigger + "触发条件不存在，无法删除");
                return;
            }
            TriggerStateID_map.Remove(trigger);
        }

        /// <summary>
        /// 根据触发条件获取到当前条件状态字典内的其对应状态ID
        /// </summary>
        /// <param name="trigger">触发条件枚举值</param>
        /// <returns></returns>
        public FSM_StateID GetTriggerID(FSM_TriggerID trigger) {
            if (TriggerStateID_map.ContainsKey(trigger))
            {
                return TriggerStateID_map[trigger];
            }
            Debug.LogError(trigger + "触发条件不存在，无法查找");
            return FSM_StateID.NullStateID;
        }


        /// <summary>
        /// 进入状态时调用，默认基类方法只赋值状态类中的fsmManger
        /// </summary>
        public virtual void EnterState(FSM_Manager fSM_Manager) 
        {
            fsmManager = fSM_Manager;
        }
        
        /// <summary>
        /// 退出状态时调用
        /// </summary>
        public virtual void ExitState(FSM_Manager fSM_Manager) { }

        /// <summary>
        /// 状态持续及刷新
        /// </summary>
        public abstract void Act_State(FSM_Manager fSM_Manager);
        /// <summary>
        /// 达到触发其他状态的条件然后执行该状态
        /// </summary>
        public virtual void TriggerState(FSM_Manager fsm_Manager)
        {
            for (int i = 0; i < triggers.Count; i++)
            {
                if(triggers[i].IsTriggerReach(fsm_Manager))
                {
                    fsm_Manager.ChangeState(triggers[i].triggerID);
                }
             }
        }

        
    }
}

