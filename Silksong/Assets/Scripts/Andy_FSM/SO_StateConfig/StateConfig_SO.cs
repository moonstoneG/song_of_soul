using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace AS_2D.FSM
{
    [CreateAssetMenu(fileName = "StateConfig_SO", menuName = "SO物体配置/状态配置SO", order = 1)]
    public class StateConfig_SO : ScriptableObject
    {
        [Tooltip("当前状态的stateID，枚举值")]
        public FSM_StateID stateID;
        [Tooltip("当前状态转换条件的枚举值列表trigger_IDs")]
        public List<FSM_TriggerID> trigger_IDs;
        [Tooltip("当前状态转换条件触发的转换状态列表，triggerID_stateID")]
        public List<triggerID_stateID> map;
        
        [Serializable]
        public struct triggerID_stateID
        {
            public FSM_TriggerID triggerID;
            public FSM_StateID stateID;
        }
    }

    
}
